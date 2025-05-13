using ApbdTestAPI.Entities;
using ApbdTestAPI.Repositories.Abstract;
using Microsoft.Data.SqlClient;

namespace ApbdTestAPI.Repositories.Extensions;

public class TaskTypeRepository : BaseRepository, ITaskTypeRepository
{
    public TaskTypeRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<TaskType?> GetTaskTypeNameByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT Name
                             FROM TaskType
                             WHERE Id = @id
                             """;
        await using SqlConnection conn = GetConnection();
        await conn.OpenAsync(cancellationToken);
        
        await using SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@id", id);
        
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (await reader.ReadAsync(cancellationToken))
        {
            return new TaskType()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
            };
        }
        return null;
    }
}