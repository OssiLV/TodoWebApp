﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server_todo.Data.Context;
using server_todo.Data.Entities;
using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.TaskTodoDto;

namespace TodoWebApp_Server_v2.Services.TaskTodoService
{
    public class TaskTodoService : ITaskTodoService
    {
        private readonly UserManager<User> _userManager;
        private readonly TodoDbContext _todoDbContext;
        private readonly IMapper _mapper;

        public TaskTodoService(TodoDbContext todoDbContext, IMapper mapper, UserManager<User> userManager )
        {
            _todoDbContext = todoDbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ResponseObjectDto> CreateTaskTodo( TaskTodoCreateRequestDto taskTodoCreateRequestDto )
        {
            TaskTodo newTaskTodo = null;


            if(taskTodoCreateRequestDto.Section_id != 0 && taskTodoCreateRequestDto.Project_id == 0)
            {
                //When has section_id
                Section checkSection = checkSection = await _todoDbContext.Sections.FindAsync(taskTodoCreateRequestDto.Section_id);
                if(checkSection == null) return new ResponseObjectDto("Cannot find section with that id");

                newTaskTodo = _mapper.Map<TaskTodo>(taskTodoCreateRequestDto);
            }

            if(taskTodoCreateRequestDto.Project_id != 0 && taskTodoCreateRequestDto.Section_id == 0)
            {
                // When has project id and "Default" name value of section
                Project checkProject = await _todoDbContext.Projects.FindAsync(taskTodoCreateRequestDto.Project_id);
                if(checkProject == null) return new ResponseObjectDto("Cannot find project with that id");

                // Query to get Section with name "Default" in Project by project_Id
                Section checkSection = await (from section in _todoDbContext.Sections
                                              join project in _todoDbContext.Projects
                                              on section.Project_id equals project.Id
                                              where project.Id == taskTodoCreateRequestDto.Project_id // Get project by taskTodoCreateRequestDto.Id
                                              where section.Name == taskTodoCreateRequestDto.SectionName // When taskTodoCreateRequestDto.SectionName == "Default"
                                              select section).FirstOrDefaultAsync();

                if(checkSection == null) return new ResponseObjectDto("Cannot find section with that name");

                taskTodoCreateRequestDto.Section_id = checkSection.Id;
                newTaskTodo = _mapper.Map<TaskTodo>(taskTodoCreateRequestDto);
            }
            
            await _todoDbContext.TaskTodos.AddAsync(newTaskTodo);
            await _todoDbContext.SaveChangesAsync();
            return new ResponseObjectDto("Created new TaskTodo", _mapper.Map<TaskTodoResponseDto>(newTaskTodo), true);
        }

        public async Task<ResponseObjectDto> GetAllTaskTodoByUserId( Guid id )
        {
            User _user = await _todoDbContext.Users.FindAsync(id);
            if(_user == null) return new ResponseObjectDto("Cannot find user with that id");

            var tasks = await (from user in _todoDbContext.Users
                               join project in _todoDbContext.Projects
                               on user.Id equals project.User_id
                               join section in _todoDbContext.Sections
                               on project.Id equals section.Project_id
                               join task in _todoDbContext.TaskTodos
                               on section.Id equals task.Section_id
                               select _mapper.Map<TaskTodoResponseDto>(task)).ToListAsync();

            if(tasks.Count <= 0) return new ResponseObjectDto("List task is empty", true);

            return new ResponseObjectDto("Success", tasks, true);
                               
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

        public async Task<ResponseObjectDto> UpdateDueDateById( long id, TaskTodoDueDateUpdateRequest taskTodoDueDateUpdateRequest )
        {
            TaskTodo checkTask = await _todoDbContext.TaskTodos.FindAsync(id);
            if(checkTask == null) return new ResponseObjectDto("Cannot find Task with that id");

            checkTask.Due_Date = taskTodoDueDateUpdateRequest.Due_Date;

            await _todoDbContext.SaveChangesAsync();
            return new ResponseObjectDto("Updated Due Date success", true);
        }

        public async Task<ResponseObjectDto> UpdatePriorityById(long id, TaskTodoPriorityUpdateRequest taskTodoPriorityUpdateRequest )
        {
            TaskTodo checkTask = await _todoDbContext.TaskTodos.FindAsync(id);
            if(checkTask == null) return new ResponseObjectDto("Cannot find Task with that id");

            checkTask.Priority = taskTodoPriorityUpdateRequest.Priority;

            await _todoDbContext.SaveChangesAsync();
            return new ResponseObjectDto("Updated priority success", true);
        }
    }
}
