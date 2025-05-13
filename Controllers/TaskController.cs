using ApbdTestAPI.Entities;
using ApbdTestAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApbdTestAPI.Controllers;
[ApiController]
[Route("/api/tasks")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<IActionResult> AddTaskAsync(TaskEntity task, CancellationToken cancellationToken = default)
    {
        await _taskService.AddTaskAsync(task, cancellationToken);
        return Ok();
    }
}