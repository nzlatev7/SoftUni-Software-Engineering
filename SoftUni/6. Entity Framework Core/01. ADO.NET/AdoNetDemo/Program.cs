
using AdoNetDemo;
using Microsoft.Data.SqlClient;
//using MySql.Data.MySqlClient;

//first we make the connection

//connection with the microsoft sql server
//string connectionString = "";
//SqlConnection conn = new SqlConnection();

//connection with the mysql
//MySqlConnection SqlConnection = new MySqlConnection("");

// ., localhost, ip, address -> the address of my computer -> 127.0.0.1

List<Employee> employees = new List<Employee>();

string connectionString = "Server=.;Database=SoftUni;Integrated Security=true;TrustServerCertificate=True";
using (SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();

    //retrieving data
    employees = RetreiveEmployees(conn);
    PrintEmployees(employees);

    //update
    UpdateEmployeesLastName(conn);

    //retrieving data
    employees = RetreiveEmployees(conn);
    PrintEmployees(employees);

    //scalar
    Console.WriteLine(ScalarMethod(conn)); 
}

static int ScalarMethod(SqlConnection conn)
{
    string query = "SELECT COUNT(*) FROM Employees";
    SqlCommand command = new SqlCommand(query, conn);

    return (int)command.ExecuteScalar();
}

static void UpdateEmployeesLastName(SqlConnection conn)
{
    string query = "UPDATE e SET e.LastName = e.LastName + '1' FROM Employees e JOIN(SELECT TOP(10) EmployeeID, FirstName, LastName FROM Employees) AS temp ON e.EmployeeID = temp.EmployeeID;";
    SqlCommand command = new SqlCommand(query, conn);

    int records = command.ExecuteNonQuery();
    Console.WriteLine(records);
}

static List<Employee> RetreiveEmployees(SqlConnection conn)
{
    List<Employee> employees = new List<Employee>();

    string query = "SELECT TOP(10) EmployeeID,FirstName,LastName FROM Employees";
    SqlCommand command = new SqlCommand(query, conn);

    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            Employee employee = new Employee(
                (int)reader["EmployeeID"],
                reader["FirstName"].ToString(),
                reader["LastName"].ToString()); ;

            employees.Add(employee);
        }
    }

    return employees;
}
static void PrintEmployees(List<Employee> employees)
{
    foreach (var employee in employees)
    {
        Console.WriteLine($"{employee.Id} {employee.FirstName} {employee.LastName}");
    }
}
