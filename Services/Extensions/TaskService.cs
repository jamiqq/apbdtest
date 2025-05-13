using ApbdTestAPI.Entities;
using ApbdTestAPI.Repositories.Extensions;
using ApbdTestAPI.Services.Abstract;

namespace ApbdTestAPI.Services;

public class TaskService : ITaskService
{
    private readonly TaskRepository _taskRepository;

    public TaskService(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<int> GetTaskById(int id, CancellationToken cancellationToken = default)
    {
        await _taskRepository.GetTaskByIdAsync(id, cancellationToken);
        return id;
    }

    public async Task<int> AddTaskAsync(TaskEntity task, CancellationToken cancellationToken = default)
    {
        await _taskRepository.AddTaskAsync(task, cancellationToken);
        return task.Id;
    }
}