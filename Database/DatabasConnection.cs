using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

public class DatabaseConnection
{
    private string connectionString = "Server=gondolin667.org;" +
                                      "Database=yhstudent12_SchoolManagementSystem;" +
                                      "User ID=yhstudent12;" +
                                      "Password=FB9OTeDr3&2B;" +
                                      "Encrypt=False;" +
                                      "TrustServerCertificate=False;";

    // Method to create and open a new connection
    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();
        return connection;
    }

}
