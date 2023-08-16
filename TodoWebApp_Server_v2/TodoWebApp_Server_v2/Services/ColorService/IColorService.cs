using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.ColorDto;

namespace TodoWebApp_Server_v2.Services.ColorService
{
    public interface IColorService
    {

        ResponseObjectDto GetAllColors(  );
        Task<ResponseObjectDto> GetColorByIdAsync( long id );
        Task<ResponseObjectDto> CreateColorAsync( ColorCreateResquestDto colorCreateResquestDto );
        Task<ResponseObjectDto> UpdateColorByIdAsync( long id, ColorUpdateRequestDto colorUpdateRequestDto );
        Task<ResponseObjectDto> DeleteColorByIdAsync( long id);
    }
}
