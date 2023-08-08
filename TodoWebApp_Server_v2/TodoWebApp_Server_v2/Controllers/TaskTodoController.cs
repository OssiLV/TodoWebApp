using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp_Server_v2.Dtos.TaskTodoDto;
using TodoWebApp_Server_v2.Services.TaskTodoService;

namespace TodoWebApp_Server_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTodoController : ControllerBase
    {
        private readonly ITaskTodoService _taskTodoService;

        public TaskTodoController(ITaskTodoService taskTodoService)
        {
            _taskTodoService = taskTodoService;
        }

        /// <summary>
        /// Create a Task Todo by Section-Id
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateTaskTodo([FromBody] TaskTodoCreateRequestDto taskTodoCreateRequestDto)
        {
            var response = await _taskTodoService.CreateTaskTodo(taskTodoCreateRequestDto);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Get all Task Todo in All Sections By Project-id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTaskTodoInSectionByProjectId( [FromRoute] long id )
        {
            var response = await _taskTodoService.GetAllTaskTodoInSectionByProjectId(id);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Update Task Completed
        /// </summary>
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> HanldeCompletedTaskTodo([FromRoute] long id)
        {
            var response = await _taskTodoService.HanldeCompletedTaskTodo(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Update Task not Complete
        /// </summary>
        [HttpPut("undocomplete/{id}")]
        public async Task<IActionResult> HanldeUndoCompletedTaskTodo( [FromRoute] long id )
        {
            var response = await _taskTodoService.HanldeUndoCompletedTaskTodo(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

    }
}
