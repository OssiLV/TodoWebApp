using AutoMapper;
using server_todo.Data.Context;
using server_todo.Data.Entities;
using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.ColorDto;

namespace TodoWebApp_Server_v2.Services.ColorService
{
    public class ColorService : IColorService
    {
        private readonly TodoDbContext _todoDbContext;
        private readonly IMapper _mapper;

        public ColorService(TodoDbContext todoDbContext, IMapper mapper)
        {
            _todoDbContext = todoDbContext;
            _mapper = mapper;
        }

        public ResponseObjectDto GetAllColors()
        {
            var color = _todoDbContext.Colors.ToList();

            if(color.Count <= 0) return new ResponseObjectDto("List colors are empty!");

            return new ResponseObjectDto("Get list color success", color, true);
        }

        public async Task<ResponseObjectDto> GetColorByIdAsync( long id )
        {
            var color = await _todoDbContext.Colors.FindAsync(id);

            if(color == null) return new ResponseObjectDto("Color is not exist!");

            return new ResponseObjectDto("Get success", _mapper.Map<ColorResponseDto>(color), true);
        }

        public async Task<ResponseObjectDto> CreateColorAsync( ColorCreateResquestDto colorCreateResquestDto )
        {
            var newColor = _mapper.Map<Color>(colorCreateResquestDto);

            await _todoDbContext.AddAsync(newColor);
           
            await _todoDbContext.SaveChangesAsync();

            return new ResponseObjectDto("Created", _mapper.Map<ColorResponseDto>(newColor), true);
        }


        public async Task<ResponseObjectDto> UpdateColorByIdAsync( long id, ColorUpdateRequestDto colorUpdateRequestDto)
        {
            var color = await _todoDbContext.Colors.FindAsync(id);

            if(color == null) return new ResponseObjectDto("Color is not exist!");

            color = _mapper.Map(colorUpdateRequestDto, color);

            await _todoDbContext.SaveChangesAsync();

            return new ResponseObjectDto("Updated", _mapper.Map<ColorResponseDto>(color), true);
        }

        public async Task<ResponseObjectDto> DeleteColorByIdAsync( long id)
        {
            var color = await _todoDbContext.Colors.FindAsync(id);

            if(color == null) return new ResponseObjectDto("Color is not exist!");

            _todoDbContext.Remove(color);

            await _todoDbContext.SaveChangesAsync();

            return new ResponseObjectDto("Deleted", true);
        }
    }
}
