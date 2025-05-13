using ApbdTestAPI.Entities;

namespace ApbdTestAPI.Repositories.Abstract;

public interface ITeamMemberRepository
{
    public Task<TeamMember?> GetTeamMemberByIdAsync(int id, CancellationToken cancellationToken = default);
}