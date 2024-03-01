using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomORM
{
    internal class DatabaseConnection
    {
        private readonly SqlConnection connection;
        private SqlTransaction transaction;
        public DatabaseConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private SqlCommand CreateCommand(string queryText, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(queryText, connection, transaction);

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

        public int ExecuteNonQuery(string queryText, params SqlParameter[] parameters)
        {
            using (SqlCommand query = CreateCommand(queryText, parameters))
            {
                return query.ExecuteNonQuery();
            }
        }

        public IEnumerable<string> FetchColumnNames(string tableName)
        {
            var rows = new List<string>();

            var queryText = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

            using (var query = CreateCommand(queryText))
            {
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rows.Add(reader[0].ToString());
                    }
                }
            }

            return rows;
        }

        public IEnumerable<T> ExecuteQuery<T>(string queryText)
        {
            var rows = new List<T>();

            using (var query = CreateCommand(queryText))
            {
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object[] columnValues = new object[reader.FieldCount];
                        reader.GetValues(columnValues);

                        var obj = reader.GetFieldValue<T>(0);
                        rows.Add(obj);
                    }
                }
            }
            return rows;
        }

        public IEnumerable<T> FetchResultSet<T>(string tableName, params string[] columnNames)
        {
            var rows = new List<T>();

            var escapedColumns = string.Join(", ", columnNames.Select(EscapeColumn));
            var queryText = $"SELECT {escapedColumns} FROM {tableName}";

            using (var query = CreateCommand(queryText))
            {
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object[] columnValues = new object[reader.FieldCount];
                        reader.GetValues(columnValues);

                        var obj = MapColumnsToObject<T>(columnNames, columnValues);
                        rows.Add(obj);
                    }
                }
            }
            return rows;
        }

        public void InsertEntities<T>(IEnumerable<T> entities, string tableName, string[] columns)
            where T : class
        {
            var identityColumns = GetIdentityColumns(tableName);

            string[] columnsToInsert = columns
                .Except(identityColumns)
                .ToArray();

            var escapedColumns = columnsToInsert
                .Select(EscapeColumn)
                .ToArray();

            var rowValues = entities
                .Select(entity => columnsToInsert
                    .Select(c => entity.GetType().GetProperty(c).GetValue(entity))
                    .ToArray())
                .ToArray();

            var rowParameterNames = Enumerable.Range(1, rowValues.Length)
                    .Select(i => columnsToInsert.Select(c => c + i)
                        .ToArray())
                    .ToArray();

            var sqlColumns = string.Join(", ", escapedColumns);

            var sqlRows = string.Join(", ", rowParameterNames
                .Select(p => 
                    string.Format("({0})",
                    string.Join(", ", p.Select(a => $"@{a}")))));

            var query = string.Format("INSERT INTO {0} ({1}) VALUES {2}",
                tableName,
                sqlColumns,
                sqlRows);


            var parameters = rowParameterNames
                .Zip(rowValues, (@params, values) =>
                    @params.Zip(values, (@param, values) =>
                        new SqlParameter(param, values ?? DBNull.Value)))
                .SelectMany(p => p)
                .ToArray();

            var insertedRows = ExecuteNonQuery(query, parameters);

            if (insertedRows != entities.Count())
            {
                throw new InvalidOperationException($"Could not insert {entities.Count() - insertedRows} rows.");
            }
        }

        public void UpdateEntites<T>(IEnumerable<T> modifiedEntities, string tableName, string[] columns)
            where T : class
        {
            var idenityColumns = GetIdentityColumns(tableName);

            var columnsToUpdate = columns.Except(idenityColumns).ToArray();

            var primaryKeyProperties = typeof(T).GetProperties()
                .Where(pi => Attribute.IsDefined(pi, typeof(KeyAttribute)))
                .ToArray();

            foreach (var entity in modifiedEntities)
            {
                var primaryKeyValues = primaryKeyProperties
                    .Select(c => c.GetValue(entity));


                var primaryKeyParameters = primaryKeyProperties
                    .Zip(primaryKeyValues, (param, value) =>
                        new SqlParameter(param.Name, value))
                    .ToArray();

                var rowValues = columnsToUpdate
                    .Select(c => entity.GetType()
                        .GetProperty(c).GetValue(entity) ?? DBNull.Value)
                    .ToArray();

                var columnsParameters = columnsToUpdate
                    .Zip(rowValues, (param, value) => new SqlParameter(param, value))
                    .ToArray();

                var columnsSql = string
                    .Join(", ", columnsToUpdate.Select(c => $"{c} = @{c}"));

                var primaryKeysSql = string
                    .Join(" AND ", primaryKeyProperties
                        .Select(pk => $"{pk.Name} = @{pk.Name}"));

                var query = string.Format($"UPDATE {0} SET {1} WHERE {2}",
                    tableName,
                    columnsSql,
                    primaryKeysSql);

                var updatedRows = ExecuteNonQuery(query,
                    columnsParameters.Concat(primaryKeyParameters).ToArray());

                if (updatedRows != 1)
                {
                    throw new InvalidOperationException($"Update for table {tableName} failed.");
                }
            }
        }

        public void DeleteEntities<T>(IEnumerable<T> entitiesToDelete, string tableName, string[] columns)
            where T : class
        {
            var primaryKeyProperties = typeof(T).GetProperties()
                .Where(pi => Attribute.IsDefined(pi, typeof(KeyAttribute)))
                .ToArray();

            foreach (var entity in entitiesToDelete)
            {
                var primaryKeyValues = primaryKeyProperties
                   .Select(c => c.GetValue(entity));

                var primaryKeyParameters = primaryKeyProperties
                    .Zip(primaryKeyValues, (param, value) =>
                        new SqlParameter(param.Name, value))
                    .ToArray();

                var primaryKeysSql = string
                    .Join(" AND ", primaryKeyProperties
                        .Select(pk => $"{pk.Name} = @{pk.Name}"));

                var query = string.Format($"DELETE FROM {0} WHERE {1}",
                    tableName,
                    primaryKeysSql);

                var updatedRows = ExecuteNonQuery(query, primaryKeyParameters);

                if (updatedRows != 1)
                {
                    throw new InvalidOperationException($"Delete for table {tableName} failed.");
                }
            }
        }

        public SqlTransaction StartTransaction()
        { 
            transaction = connection.BeginTransaction();
            return transaction;
        }
        public void Open()
        {
            connection.Open();
        }
        public void Close()
        {
            connection.Close();
        }

        private IEnumerable<string> GetIdentityColumns(string tableName)
        {
            const string identityColumnsSql = "SELECT COLUMN_NAME FROM (SELECT COLUMN_NAME, COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'isIdentity') as IsIdentity FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}') AS IdentitySpacs WHERE IsIdentity = 1";

            var parametrizedSql = string.Format(identityColumnsSql, tableName);

            var identiyColumns = ExecuteQuery<string>(parametrizedSql);

            return identiyColumns;
        }

        private T MapColumnsToObject<T>(string[] columnNames, object[] columnValues)
        {
            var obj = Activator.CreateInstance<T>();

            for (int i = 0; i < columnValues.Length; i++)
            {
                var columnName = columnNames[i];
                var columnValue = columnValues[i];

                if (columnValue is DBNull)
                {
                    columnValue = null;
                }

                var property = typeof(T).GetProperty(columnName);
                property.SetValue(obj, columnValue);
            }

            return obj;
        }

        private object EscapeColumn(string c)
        {
            var escapedColumn = $"[{c}]";
            return escapedColumn;
        }
    }
}
