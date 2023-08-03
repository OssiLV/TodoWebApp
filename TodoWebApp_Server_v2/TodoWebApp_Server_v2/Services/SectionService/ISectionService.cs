using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.SectionDto;

namespace TodoWebApp_Server_v2.Services.SectionService
{
    public interface ISectionService
    {
        Task<ResponseObjectDto> GetAllSectionByProjectId( long id );
        Task<ResponseObjectDto> GetSectionByName( string name );
        Task<ResponseObjectDto> CreateSection( SectionCreateRequestDto SectionCreateRequestDto );
        Task<ResponseObjectDto> UpdateSectionById( long id, SectionUpdateRequestDto SectionUpdateRequestDto );
        Task<ResponseObjectDto> DeleSectionById( long id );
    }
}
