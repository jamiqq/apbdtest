using ApbdTestAPI.Entities;

namespace ApbdTestAPI.Repositories.Abstract;

public interface ITaskTypeRepository
{
    public Task<TaskType?> GetTaskTypeNameByIdAsync(int id, CancellationToken cancellationToken = default);
}