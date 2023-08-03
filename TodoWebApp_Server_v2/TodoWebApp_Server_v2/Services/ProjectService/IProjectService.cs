using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.ProjectDto;

namespace TodoWebApp_Server_v2.Services.ProjectService
{
    public interface IProjectService
    {
        Task<ResponseObjectDto> GetAllProjectAndSectionByUserId( Guid Id );
        Task<ResponseObjectDto> GetAllProjectByUserId( Guid Id );
        Task<ResponseObjectDto> GetProjectByName( string name );
        Task<ResponseObjectDto> CreateProject( ProjectCreateRequestDto projectCreateRequestDto );
        Task<ResponseObjectDto> UpdateProjectById(long id ,ProjectUpdateRequestDto projectUpdateRequestDto );
        Task<ResponseObjectDto> ForceDeleteProjectById( long id );
        Task<ResponseObjectDto> SoftDeleteProjectById( long id );
        Task<ResponseObjectDto> UndoDeleteProjectById( long id );

    }
}
