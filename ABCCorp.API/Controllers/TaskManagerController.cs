using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCCorp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABCCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskManagerController : ControllerBase
    {
        private readonly ITaskManagerService _taskMngService;


        public TaskManagerController(ITaskManagerService taskMngService)
        {
            _taskMngService = taskMngService;
        }

        [HttpGet("/api/empolyee/tasks")]
        public async Task<IActionResult> Get([FromQuery] int employeeId)
        {
            return Ok(await _taskMngService.GetEmployeeTasks(employeeId));
        }

        [HttpPost("/api/empolyee/markTaskAsCompleted")]
        public async Task<IActionResult> Get([FromQuery] int employeeId, [FromQuery] int taskId)
        {
            return Ok(await _taskMngService.MarkTaskAsCompleted(employeeId, taskId));
        }
    }
}
