using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server_todo.Data.Context;
using server_todo.Data.Entities;
using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.ColorDto;
using TodoWebApp_Server_v2.Dtos.ProjectDto;
using TodoWebApp_Server_v2.Dtos.SectionDto;

namespace TodoWebApp_Server_v2.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly TodoDbContext _todoDbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public ProjectService( TodoDbContext todoDbContext, UserManager<User> userManager, IMapper mapper )
        {
            _todoDbContext = todoDbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResponseObjectDto> GetAllProjectAndSectionByUserIdAsync( Guid Id )
        {
            if(string.IsNullOrEmpty(Id.ToString())) return new ResponseObjectDto("Invalid value!");

            User user = await _todoDbContext.Users.FindAsync(Id);
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");

            var listProject = await (from project in _todoDbContext.Projects
                                     join color in _todoDbContext.Colors
                                     on project.Color_id equals color.Id
                                     join section in _todoDbContext.Sections
                                     on project.Id equals section.Project_id
                                     where project.User_id == Id
                                     select new ProjectResponseDto_v2
                                     {
                                         Id = project.Id,
                                         Name = project.Name,
                                         IsFavorite = project.IsFavorite,
                                         IsDeleted = project.IsDeleted,
                                         Color = _mapper.Map<ColorResponseDto>(project.Color),
                                         Sections = (List<SectionResponseDto>)_todoDbContext.Sections.Where(x => x.Project_id == project.Id).Select(x => _mapper.Map<SectionResponseDto>(x))

                                     }
                                     ).ToListAsync();

            if(listProject.Count <= 0) return new ResponseObjectDto("List projects are empty!", true);

            return new ResponseObjectDto("Success", listProject, true);


        }
        public async Task<ResponseObjectDto> GetAllProjectByUserIdAsync( Guid Id )
        {
            if(string.IsNullOrEmpty(Id.ToString())) return new ResponseObjectDto("Invalid value!");

            User user = await _todoDbContext.Users.FindAsync(Id);
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");

            var listProject = await (from project in _todoDbContext.Projects
                                     join color in _todoDbContext.Colors
                                     on project.Color_id equals color.Id
                                     where project.User_id == Id
                                     select new ProjectResponseDto
                                     {
                                         Id = project.Id,
                                         Name = project.Name,
                                         IsFavorite = project.IsFavorite,
                                         IsDeleted = project.IsDeleted,
                                         Color = _mapper.Map<ColorResponseDto>(project.Color),
                                     }
                                     ).ToListAsync();

            if(listProject.Count <= 0) return new ResponseObjectDto("List projects are empty!", true);

            return new ResponseObjectDto("Success", listProject, true);
        }

        public async Task<ResponseObjectDto> GetProjectByNameAsync( string name )
        {
            if(string.IsNullOrEmpty(name)) return new ResponseObjectDto("Invalid value");

            Project project = await _todoDbContext.Projects.FirstOrDefaultAsync(x => x.Name == name);

            if(project == null) return new ResponseObjectDto("There is no project with that name");

            return new ResponseObjectDto("Success", project, true);
        }

        public async Task<ResponseObjectDto> CreateProjectAsync( ProjectCreateRequestDto projectCreateRequestDto )
        {
            if(string.IsNullOrEmpty(projectCreateRequestDto.Name) | string.IsNullOrEmpty(projectCreateRequestDto.Color_id.ToString()))
                return new ResponseObjectDto("Invalid value");
            User user = await _userManager.FindByIdAsync(projectCreateRequestDto.User_id.ToString());
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");


            Project newProject = _mapper.Map<Project>(projectCreateRequestDto);

            await _todoDbContext.Projects.AddAsync(newProject);

            await _todoDbContext.SaveChangesAsync();


            Section newDefaultSection = new Section();
            newDefaultSection.Name = "Default";
            newDefaultSection.Project_id = newProject.Id;

            await _todoDbContext.Sections.AddAsync(newDefaultSection);
            await _todoDbContext.SaveChangesAsync();

            var projectResponse = await (from project in _todoDbContext.Projects
                                         join color in _todoDbContext.Colors
                                         on project.Color_id equals color.Id
                                         where project.Id == newProject.Id
                                         select new ProjectResponseDto
                                         {
                                             Id = project.Id,
                                             Name = project.Name,
                                             IsFavorite = project.IsFavorite,
                                             IsDeleted = project.IsDeleted,
                                             Color = _mapper.Map<ColorResponseDto>(project.Color),
                                         }
                                         ).FirstOrDefaultAsync();

            return new ResponseObjectDto("Created", projectResponse, true);
        }


        public async Task<ResponseObjectDto> UpdateProjectByIdAsync( long id, ProjectUpdateRequestDto projectUpdateRequestDto )
        {
            Project project = await _todoDbContext.Projects.FindAsync(id);

            if(project == null) return new ResponseObjectDto("Project is not exist!");

            project = _mapper.Map(projectUpdateRequestDto, project);

            await _todoDbContext.SaveChangesAsync();

            return new ResponseObjectDto("Updated", _mapper.Map<ProjectResponseDto>(project), true);
        }

        public async Task<ResponseObjectDto> ForceDeleteProjectByIdAsync( long id )
        {
            var project = await _todoDbContext.Projects.FindAsync(id);

            if(project == null) return new ResponseObjectDto("Projetc is not exist!");

            if(project.IsDeleted)
            {
                _todoDbContext.Remove(project);
                await _todoDbContext.SaveChangesAsync();
            }
            else
            {
                return new ResponseObjectDto("isDelete must be set true");
            }

            return new ResponseObjectDto("Deleted", true);
        }

        public async Task<ResponseObjectDto> SoftDeleteProjectByIdAsync( long id )
        {
            var project = await _todoDbContext.Projects.FindAsync(id);

            if(project == null) return new ResponseObjectDto("Project is not exist!");

            project.IsDeleted = true;

            await _todoDbContext.SaveChangesAsync();

            return new ResponseObjectDto("Soft Deleted", true);
        }

        public async Task<ResponseObjectDto> UndoDeleteProjectByIdAsync( long id )
        {
            var project = await _todoDbContext.Projects.FindAsync(id);

            if(project == null) return new ResponseObjectDto("Project is not exist!");

            if(project.IsDeleted)
            {
                project.IsDeleted = false;
                await _todoDbContext.SaveChangesAsync();

            }
            else
            {
                return new ResponseObjectDto("isDelete must be set true");
            }
            var projectResponse = await (from _project in _todoDbContext.Projects
                                         join color in _todoDbContext.Colors
                                         on project.Color_id equals color.Id
                                         where _project.Id == project.Id
                                         select new ProjectResponseDto
                                         {
                                             Id = _project.Id,
                                             Name = _project.Name,
                                             IsFavorite = _project.IsFavorite,
                                             IsDeleted = _project.IsDeleted,
                                             Color = _mapper.Map<ColorResponseDto>(_project.Color),
                                         }
                                        ).FirstOrDefaultAsync();

            return new ResponseObjectDto("Undo Success", _mapper.Map<ProjectResponseDto>(projectResponse), true);
        }


    }
}
