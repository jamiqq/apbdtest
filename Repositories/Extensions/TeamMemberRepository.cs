using ApbdTestAPI.Entities;
using ApbdTestAPI.Repositories.Abstract;
using Microsoft.Data.SqlClient;

namespace ApbdTestAPI.Repositories.Extensions;

public class TeamMemberRepository : BaseRepository, ITeamMemberRepository
{
    public TeamMemberRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<TeamMember?> GetTeamMemberByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT *
                             FROM TeamMember
                             WHERE Id = @id
                             """;
        
        await using SqlConnection connection = GetConnection();
        await connection.OpenAsync(cancellationToken);
        
        await using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);

        if (await reader.ReadAsync(cancellationToken))
        {
            return new TeamMember()
            {
                Id = (int)reader["Id"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Email = (string)reader["Email"],

            };
        }
        return null;
    }
}