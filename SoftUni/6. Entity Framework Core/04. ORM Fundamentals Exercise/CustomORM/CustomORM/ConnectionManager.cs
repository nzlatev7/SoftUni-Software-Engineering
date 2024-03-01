using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomORM
{
    internal class ConnectionManager : IDisposable
    {
        private readonly DatabaseConnection connection;
        public ConnectionManager(DatabaseConnection connection)
        {
            this.connection = connection;
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
