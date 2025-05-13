using ApbdTestAPI.Entities;
using ApbdTestAPI.Repositories.Abstract;
using Microsoft.Data.SqlClient;

namespace ApbdTestAPI.Repositories.Extensions;

public class ProjectRepository : BaseRepository, IProjectRepository
{
    public ProjectRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<Project?> GetProjectNameByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT Name
                             FROM Project
                             WHERE Id = @id
                             ORDER BY Deadlien DESC
                             """;
        
        await using SqlConnection conn = GetConnection();
        await conn.OpenAsync(cancellationToken);
        
        await using SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@id", id);
        
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (await reader.ReadAsync(cancellationToken))
        {
            return new Project()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Deadline = reader.GetDateTime(2),
            };
        }
        return null;
    }
}