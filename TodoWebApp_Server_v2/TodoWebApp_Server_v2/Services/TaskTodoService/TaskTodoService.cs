using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server_todo.Data.Context;
using server_todo.Data.Entities;
using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.TaskTodoDto;

namespace TodoWebApp_Server_v2.Services.TaskTodoService
{
    public class TaskTodoService : ITaskTodoService
    {
        private readonly TodoDbContext _todoDbContext;
        private readonly IMapper _mapper;

        public TaskTodoService(TodoDbContext todoDbContext, IMapper mapper)
        {
            _todoDbContext = todoDbContext;
            _mapper = mapper;
        }
        public async Task<ResponseObjectDto> CreateTaskTodo( TaskTodoCreateRequestDto taskTodoCreateRequestDto )
        {
            Section checkSection = null;
            TaskTodo newTaskTodo = null;

            if(string.IsNullOrEmpty(taskTodoCreateRequestDto.SectionName))
            {
                checkSection = await _todoDbContext.Sections.FindAsync(taskTodoCreateRequestDto.Section_id);
                if(checkSection == null) return new ResponseObjectDto("Cannot find section with that id");

                newTaskTodo = _mapper.Map<TaskTodo>(taskTodoCreateRequestDto);
            }
            else
            {
                checkSection = await _todoDbContext.Sections.FirstOrDefaultAsync(x => x.Name == taskTodoCreateRequestDto.SectionName);
                if(checkSection == null) return new ResponseObjectDto("Cannot find section with that name");

                taskTodoCreateRequestDto.Section_id = checkSection.Id;
                newTaskTodo = _mapper.Map<TaskTodo>(taskTodoCreateRequestDto);
            }

            
            await _todoDbContext.TaskTodos.AddAsync(newTaskTodo);
            await _todoDbContext.SaveChangesAsync();
            return new ResponseObjectDto("Created new TaskTodo", _mapper.Map<TaskTodoResponseDto>(newTaskTodo), true);
        }

        public async Task<ResponseObjectDto> GetAllTaskTodoInSectionByProjectId( long id )
        {
            if(string.IsNullOrEmpty(id.ToString())) return new ResponseObjectDto("Invalid value!");

            Project checkProject = await _todoDbContext.Projects.FindAsync(id);
            if(checkProject == null) return new ResponseObjectDto("Cannot find Project with that id");

            var listTaskTodos = await (from taskTodo in _todoDbContext.TaskTodos
                                 join section in _todoDbContext.Sections
                                 on taskTodo.Section_id equals section.Id
                                 join project in _todoDbContext.Projects
                                 on section.Project_id equals project.Id
                                 where project.Id == id
                                 select _mapper.Map<TaskTodoResponseDto>(taskTodo)).ToListAsync();

            if(listTaskTodos.Count <= 0) return new ResponseObjectDto("List Tasks are empty!", true);

            return new ResponseObjectDto("Get All Task Todo success!", listTaskTodos, true);
        }

        public async Task<ResponseObjectDto> HanldeCompletedTaskTodo( long id )
        {
            TaskTodo checkTask = await _todoDbContext.TaskTodos.FindAsync(id);
            if(checkTask == null) return new ResponseObjectDto("Cannot find Task with that id");

            checkTask.IsCompleted = true;

            await _todoDbContext.SaveChangesAsync();
            return new ResponseObjectDto("Set isCompleted: true", true);
        }

        public async Task<ResponseObjectDto> HanldeUndoCompletedTaskTodo( long id )
        {
            TaskTodo checkTask = await _todoDbContext.TaskTodos.FindAsync(id);
            if(checkTask == null) return new ResponseObjectDto("Cannot find Task with that id");

            checkTask.IsCompleted = false;

            await _todoDbContext.SaveChangesAsync();
            return new ResponseObjectDto("Set isCompleted: false", true);
        }
    }
}
