using System.Data.Common;
using MySqlConnector;
using Store.Proyect.Api.DataAccess.Interfaces;

namespace Store.Proyect.Api.DataAccess;


public class DbContext : IDbContext
{
    
    private readonly string _connectionString = 
        "server=localhost;user=root;password=1234;database=StoreDB;port=3306";
    
    private MySqlConnection _connection;
    
    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }

            return _connection;
        }
    }
}