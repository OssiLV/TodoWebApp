using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server_todo.Data.Context;
using server_todo.Data.Entities;
using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.ProjectDto;
using TodoWebApp_Server_v2.Dtos.SectionDto;

namespace TodoWebApp_Server_v2.Services.SectionService
{
    public class SectionService : ISectionService
    {
        private readonly TodoDbContext _todoDbContext;
        private readonly IMapper _mapper;

        public SectionService(TodoDbContext todoDbContext, IMapper mapper)
        {
            _todoDbContext = todoDbContext;
            _mapper = mapper;
        }
        public async Task<ResponseObjectDto> CreateSectionAsync( SectionCreateRequestDto SectionCreateRequestDto )
        {
            if(string.IsNullOrEmpty(SectionCreateRequestDto.Name)) return new ResponseObjectDto("Invalid value");


            Section newSection = _mapper.Map<Section>(SectionCreateRequestDto);

            await _todoDbContext.Sections.AddAsync(newSection);

            await _todoDbContext.SaveChangesAsync();


            return new ResponseObjectDto("Created", _mapper.Map<SectionResponseDto>(newSection), true);
        }

        public Task<ResponseObjectDto> DeleSectionByIdAsync( long id )
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseObjectDto> GetAllSectionByProjectIdAsync( long id )
        {

            if(string.IsNullOrEmpty(id.ToString())) return new ResponseObjectDto("Invalid value!");
            var listSection = await (from section in _todoDbContext.Sections
                                     where section.Project_id == id
                                     select _mapper.Map<SectionResponseDto>(section)).ToListAsync();

            if(listSection.Count <= 0) return new ResponseObjectDto("List sections are empty!", true);

            return new ResponseObjectDto("Success", listSection, true);
        }

        public Task<ResponseObjectDto> GetSectionByNameAsync( string name )
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObjectDto> UpdateSectionByIdAsync( long id, SectionUpdateRequestDto SectionUpdateRequestDto )
        {
            throw new NotImplementedException();
        }
    }
}
