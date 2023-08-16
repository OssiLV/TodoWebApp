using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp_Server_v2.Dtos.TaskTodoDto;
using TodoWebApp_Server_v2.Services.TaskTodoService;

namespace TodoWebApp_Server_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var response = await _taskTodoService.CreateTaskTodoAsync(taskTodoCreateRequestDto);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Get all Task Todo by User_id
        /// </summary>
        [HttpGet("userid/{id}")]
        public async Task<IActionResult> GetAllTaskTodoInSectionByProjectId( [FromRoute] Guid id )
        {
            var response = await _taskTodoService.GetAllTaskTodoByUserIdAsync(id);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Get all Task Todo in All Sections By Project-id
        /// </summary>
        [HttpGet("projectid/{id}")]
        public async Task<IActionResult> GetAllTaskTodoInSectionByProjectId( [FromRoute] long id )
        {
            var response = await _taskTodoService.GetAllTaskTodoInSectionByProjectIdAsync(id);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Update Task Completed
        /// </summary>
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> HanldeCompletedTaskTodo([FromRoute] long id)
        {
            var response = await _taskTodoService.HanldeCompletedTaskTodoAsync(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Undo task completed
        /// </summary>
        [HttpPut("undocomplete/{id}")]
        public async Task<IActionResult> HanldeUndoCompletedTaskTodo( [FromRoute] long id )
        {
            var response = await _taskTodoService.HanldeUndoCompletedTaskTodoAsync(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Update priotity for TaskTodo
        /// </summary>
        [HttpPut("priority/{id}")]
        public async Task<IActionResult> UpdatePriorityById( [FromRoute] long id, [FromBody] TaskTodoPriorityUpdateRequest taskTodoPriorityUpdateRequest )
        {
            var response = await _taskTodoService.UpdatePriorityByIdAsync(id, taskTodoPriorityUpdateRequest);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Update Due Date for TaskTodo
        /// </summary>
        [HttpPut("duedate/{id}")]
        public async Task<IActionResult> UpdateDueDateById( [FromRoute] long id, [FromBody] TaskTodoDueDateUpdateRequest taskTodoDueDateUpdateRequest )
        {
            var response = await _taskTodoService.UpdateDueDateByIdAsync(id, taskTodoDueDateUpdateRequest);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }


        /// <summary>
        /// Reschedule task with array id
        /// </summary>
        [HttpPut("reschedule")]
        public async Task<IActionResult> RescheduleForManyTasks( [FromBody] TaskTodoRescheduleRequestDto taskTodoRescheduleRequest )
        {
            var response = await _taskTodoService.RescheduleForManyTasksAsync(taskTodoRescheduleRequest);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

    }
}
