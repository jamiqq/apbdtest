using Microsoft.Data.SqlClient;

namespace ApbdTestAPI.Repositories;

public class BaseRepository
{
    private readonly string _connectionString;

    public BaseRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}