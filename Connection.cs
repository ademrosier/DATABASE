using Microsoft.Data.SqlClient;
using System;

class Connection
{
    public Connection()
    {
    }
    public string OpenSqlConnection()
    {
        string connectionString = GetConnectionString();
        return connectionString;

    }

    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file.
        return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hotel;Integrated Security=True;"
                                    + "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}