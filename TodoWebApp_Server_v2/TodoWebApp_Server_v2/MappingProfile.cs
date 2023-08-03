using AutoMapper;
using server_todo.Data.Entities;
using TodoWebApp_Server_v2.Dtos.ColorDto;
using TodoWebApp_Server_v2.Dtos.ProjectDto;
using TodoWebApp_Server_v2.Dtos.SectionDto;
using TodoWebApp_Server_v2.Dtos.TaskTodoDto;
using TodoWebApp_Server_v2.Dtos.UserDto;

namespace TodoWebApp_Server_v2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User
            CreateMap<User, UserResponseDto>();

            //Color
            CreateMap<Color, ColorResponseDto>();
            CreateMap<ColorCreateResquestDto, Color>();
            CreateMap<ColorUpdateRequestDto, Color>();

            //Project
            CreateMap<Project, ProjectResponseDto>();
            CreateMap<Project, ListProjectResponseDto>();
            CreateMap<ProjectCreateRequestDto, Project>();
            CreateMap<ProjectUpdateRequestDto, Project>();

            //Section
            CreateMap<Section, SectionResponseDto>();
            CreateMap<SectionCreateRequestDto, Section>();

            //TaskTodo
            CreateMap<TaskTodo, TaskTodoResponseDto>();
            CreateMap<TaskTodoCreateRequestDto, TaskTodo>();

        }
    }
}
