using ApbdTestAPI.Entities;

namespace ApbdTestAPI.Services.Abstract;

public interface ITaskService
{
    public Task<int> GetTaskById(int id, CancellationToken cancellationToken = default);
    
    public Task<int> AddTaskAsync(TaskEntity task, CancellationToken cancellationToken = default);
}