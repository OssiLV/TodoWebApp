using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.ColorDto;

namespace TodoWebApp_Server_v2.Services.ColorService
{
    public interface IColorService
    {

        ResponseObjectDto GetAllColors(  );
        Task<ResponseObjectDto> GetColorById( long id );
        Task<ResponseObjectDto> CreateColor( ColorCreateResquestDto colorCreateResquestDto );
        Task<ResponseObjectDto> UpdateColorById( long id, ColorUpdateRequestDto colorUpdateRequestDto );
        Task<ResponseObjectDto> DeleteColorById( long id);
    }
}
