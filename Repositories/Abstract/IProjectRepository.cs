using ApbdTestAPI.Entities;

namespace ApbdTestAPI.Repositories.Abstract;

public interface IProjectRepository
{
    public Task<Project?> GetProjectNameByIdAsync(int id, CancellationToken cancellationToken = default);
}