using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectsQueryAPI.Data;

public class DbConnection
{
    private readonly string _connectionString;

    public DbConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }

    public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
}
