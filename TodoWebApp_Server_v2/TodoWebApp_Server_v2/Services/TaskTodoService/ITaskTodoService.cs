using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.TaskTodoDto;

namespace TodoWebApp_Server_v2.Services.TaskTodoService
{
    public interface ITaskTodoService
    {
        Task<ResponseObjectDto> CreateTaskTodoAsync(TaskTodoCreateRequestDto taskTodoCreateRequestDto);
        Task<ResponseObjectDto> GetAllTaskTodoInSectionByProjectIdAsync( long id );
        Task<ResponseObjectDto> GetAllTaskTodoByUserIdAsync( Guid id );
        Task<ResponseObjectDto> HanldeCompletedTaskTodoAsync( long id );
        Task<ResponseObjectDto> HanldeUndoCompletedTaskTodoAsync( long id );
        Task<ResponseObjectDto> RescheduleForManyTasksAsync( TaskTodoRescheduleRequestDto taskTodoRescheduleRequestDto );
        Task<ResponseObjectDto> UpdatePriorityByIdAsync( long id, TaskTodoPriorityUpdateRequest taskTodoPriorityUpdateRequest );
        Task<ResponseObjectDto> UpdateDueDateByIdAsync( long id, TaskTodoDueDateUpdateRequest  taskTodoDueDateUpdateRequest);
    }
}
