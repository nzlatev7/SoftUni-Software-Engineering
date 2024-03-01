
using Microsoft.Data.SqlClient;

using SqlConnection conn = new SqlConnection(
    "Server=.;Database=MinionsDb;Integrated Security=True;TrustServerCertificate=True");

conn.Open();

//1
//string query = "CREATE DATABASE MinionsDB";
//SqlCommand command = new SqlCommand(query, conn);
//command.ExecuteNonQuery();

//2
//string query = "SELECT Name, COUNT(MinionId) AS [Count] FROM Villains v JOIN MinionsVillains m ON v.Id = m.VillainId GROUP BY Name HAVING COUNT(MinionId) > 2 ORDER BY COUNT(MinionId) DESC";
//SqlCommand command = new SqlCommand(query, conn);
//using (SqlDataReader reader = command.ExecuteReader())
//{
//    while (reader.Read())
//    {
//        Console.WriteLine($"{reader["Name"]} {reader["Count"]}");
//    }
//}

//3
//int villainId = int.Parse(Console.ReadLine());
//string queryGetNameById = "select Name from Villains where id = @VillainId";
//string queryGetAllMinions = "SELECT Name, Age FROM Minions m JOIN MinionsVillains mv ON m.Id = mv.MinionId WHERE MV.VillainId = @VillainId ORDER BY Name";

//using SqlCommand command = new SqlCommand(queryGetNameById, conn);
//command.Parameters.AddWithValue("@VillainId", villainId);

//string reader1 = (string)command.ExecuteScalar();

//if (reader1 == null)
//{
//    Console.WriteLine($"No villain with ID {villainId} exists in the db.");
//    return;
//}
//else
//{
//    Console.WriteLine(reader1);
//}

//using SqlCommand command2 = new SqlCommand(queryGetAllMinions, conn);
//command2.Parameters.AddWithValue("@VillainId", villainId);

//int counter = 1;
//using (SqlDataReader reader2 = command2.ExecuteReader())
//{

//    if (!reader2.HasRows)
//    {
//        Console.WriteLine("(no minions)");
//    }

//    while (reader2.Read())
//    {
//        Console.WriteLine($"{counter++}. {reader2["Name"]} {reader2["Age"]}");
//    }
//}

//4
//string[] minionInfo = Console.ReadLine()
//    .Split(" ")
//    .ToArray();

//string[] villainInfo = Console.ReadLine()
//    .Split(" ")
//    .ToArray();

//string minionName = minionInfo[1];
//string minionAge = minionInfo[2];
//string townName = minionInfo[3];
//string villainName = villainInfo[1];

//string querySearchTown = "SELECT COUNT(*) FROM Towns where Name=@TownName";
//using SqlCommand command = new SqlCommand(querySearchTown, conn);
//command.Parameters.AddWithValue("@TownName", townName);

//int scalarResult = (int)command.ExecuteScalar();

//if (scalarResult == 0)
//{
//    string queryInsertTown = "insert into Towns(Name, CountryId) values (@TownName, 1)";
//    using SqlCommand command2 = new SqlCommand(queryInsertTown, conn);
//    command2.Parameters.AddWithValue("@TownName", townName);
//    int a = command2.ExecuteNonQuery();

//    Console.WriteLine($"Town {townName} was added to the database.");
//}

//string querySearchForVillain = "select COUNT(*) from Villains where Name = @VillainName";
//using SqlCommand command3 = new SqlCommand(querySearchForVillain, conn);
//command3.Parameters.AddWithValue("@VillainName", villainName);

//int scalarResult2 = (int)command3.ExecuteScalar();

//if (scalarResult2 == 0)
//{
//    string queryInsert = "insert into Villains(Name, EvilnessFactorId) values(@VillainName, 4)";
//    using SqlCommand command4 = new SqlCommand(queryInsert, conn);
//    command4.Parameters.AddWithValue("@VillainName", villainName);
//    command4.ExecuteNonQuery();
//    Console.WriteLine($"Villain {villainName} was added to the database.");
//}

//string queryGetMinionId = "select id from Minions where Name = @MinionName";
//using SqlCommand command5 = new SqlCommand(queryGetMinionId, conn);
//command5.Parameters.AddWithValue("@MinionName", minionName);
//int minionId = (int)command5.ExecuteScalar();

//string queryGetVillainId = "select id from Villains where Name = @VillainName";
//using SqlCommand command7 = new SqlCommand(queryGetVillainId, conn);
//command7.Parameters.AddWithValue("@VillainName", villainName);
//int villainId = (int)command7.ExecuteScalar();

//string queryInsertServant= "insert into MinionsVillains(MinionId, VillainId) values (@MinionId, @VillainId)";
//using SqlCommand command6 = new SqlCommand(queryInsertServant, conn);
//command6.Parameters.AddWithValue("@MinionId", minionId);
//command6.Parameters.AddWithValue("@VillainId", villainId);
//command6.ExecuteNonQuery();

//Console.WriteLine($"Succesfully added {minionName} to be minion of {villainName}");


//5

////create transaction - wrap the code in single unit
//using SqlTransaction sqlTran = conn.BeginTransaction();

//int villainId = int.Parse(Console.ReadLine());

//string querySearchForVillain = "select COUNT(*) from Villains where Id = @VillainId";

////enlist the current command in the transaction
//using SqlCommand command = new SqlCommand(querySearchForVillain, conn);
//command.Transaction = sqlTran;
//command.Parameters.AddWithValue("@VillainId", villainId);

//int scalarResult = (int)command.ExecuteScalar();

//if (scalarResult == 0)
//{
//    Console.WriteLine("No such villain was found.");
//    return;
//}

//try
//{
//    string queryReleaseMinions = "delete from MinionsVillains where VillainId = @VillainId";
//    using SqlCommand command2 = new SqlCommand(queryReleaseMinions, conn);
//    command2.Transaction = sqlTran;
//    command2.Parameters.AddWithValue("@VillainId", villainId);
//    int releaseMinionsCount = command2.ExecuteNonQuery();

//    string queryForDeleteVillain = "delete from Villains where Id = @VillainId";
//    using SqlCommand command3 = new SqlCommand(queryForDeleteVillain, conn);
//    command3.Transaction = sqlTran;
//    command3.Parameters.AddWithValue("@VillainId", villainId);
//    command3.ExecuteNonQuery();

//    //commit all changes
//    sqlTran.Commit();

//    Console.WriteLine(releaseMinionsCount);
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//    sqlTran.Rollback();
//}

int minionId = int.Parse(Console.ReadLine());

string queryIncreaseMinionAge = "EXEC usp_GetOlder @MinionId";
using SqlCommand command = new SqlCommand(queryIncreaseMinionAge, conn);
command.Parameters.AddWithValue("@MinionId", minionId);
command.ExecuteNonQuery();

string queryGetMinionInfo = "Select Name,Age from Minions where Id=@MinionId";
using SqlCommand command2 = new SqlCommand(queryGetMinionInfo, conn);
command2.Parameters.AddWithValue("@MinionId", minionId);

using SqlDataReader reader = command2.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
}