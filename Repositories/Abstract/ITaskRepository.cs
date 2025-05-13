using ApbdTestAPI.Entities;

namespace ApbdTestAPI.Repositories.Abstract;

public interface ITaskRepository
{
    public Task<TaskEntity> GetTaskByIdAsync(int id, CancellationToken cancellationToken = default);
    
    public Task<int> AddTaskAsync(TaskEntity task, CancellationToken cancellationToken = default);
}