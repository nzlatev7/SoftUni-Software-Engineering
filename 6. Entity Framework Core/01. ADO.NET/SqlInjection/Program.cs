
using Microsoft.Data.SqlClient;

Console.Write("Username: ");
string username = Console.ReadLine();
Console.Write("Password: ");
string password = Console.ReadLine();

using SqlConnection conn = new SqlConnection(
    "Server=.;Database=DemoSqlInjection;Integrated Security=true;TrustServerCertificate=True");

conn.Open();

//the bad way
//string query = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}' AND Password = '{password}'";

//the right way, preventing the sql injection
string query = $"SELECT COUNT(*) FROM Users WHERE Username = '@Username' AND Password = '@Password'";
using SqlCommand command = new SqlCommand(query, conn);
command.Parameters.AddWithValue("@Username", username);
command.Parameters.AddWithValue("@Password", password);

int result = (int)command.ExecuteScalar();
if (result == 1)
{
    Console.WriteLine("you loged in succesfully");
}
else
{
    Console.WriteLine("access denied");
}

