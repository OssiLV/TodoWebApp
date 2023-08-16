using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.ProjectDto;

namespace TodoWebApp_Server_v2.Services.ProjectService
{
    public interface IProjectService
    {
        Task<ResponseObjectDto> GetAllProjectAndSectionByUserIdAsync( Guid Id );
        Task<ResponseObjectDto> GetAllProjectByUserIdAsync( Guid Id );
        Task<ResponseObjectDto> GetProjectByNameAsync( string name );
        Task<ResponseObjectDto> CreateProjectAsync( ProjectCreateRequestDto projectCreateRequestDto );
        Task<ResponseObjectDto> UpdateProjectByIdAsync( long id ,ProjectUpdateRequestDto projectUpdateRequestDto );
        Task<ResponseObjectDto> ForceDeleteProjectByIdAsync( long id );
        Task<ResponseObjectDto> SoftDeleteProjectByIdAsync( long id );
        Task<ResponseObjectDto> UndoDeleteProjectByIdAsync( long id );

    }
}
