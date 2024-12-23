using Microsoft.AspNetCore.Mvc;
using ABCCorp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ABCCorp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;


    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("/api/tasks")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _taskService.GetTasks());
    }
}

