using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.TaskTodoDto;

namespace TodoWebApp_Server_v2.Services.TaskTodoService
{
    public interface ITaskTodoService
    {
        Task<ResponseObjectDto> CreateTaskTodo(TaskTodoCreateRequestDto taskTodoCreateRequestDto);
        Task<ResponseObjectDto> GetAllTaskTodoInSectionByProjectId( long id );
        Task<ResponseObjectDto> HanldeCompletedTaskTodo( long id );
        Task<ResponseObjectDto> HanldeUndoCompletedTaskTodo( long id );
    }
}
