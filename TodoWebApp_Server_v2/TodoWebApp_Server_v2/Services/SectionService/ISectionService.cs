using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.SectionDto;

namespace TodoWebApp_Server_v2.Services.SectionService
{
    public interface ISectionService
    {
        Task<ResponseObjectDto> GetAllSectionByProjectIdAsync( long id );
        Task<ResponseObjectDto> GetSectionByNameAsync( string name );
        Task<ResponseObjectDto> CreateSectionAsync( SectionCreateRequestDto SectionCreateRequestDto );
        Task<ResponseObjectDto> UpdateSectionByIdAsync( long id, SectionUpdateRequestDto SectionUpdateRequestDto );
        Task<ResponseObjectDto> DeleSectionByIdAsync( long id );
    }
}
