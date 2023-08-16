using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp_Server_v2.Dtos.ProjectDto;
using TodoWebApp_Server_v2.Dtos.SectionDto;
using TodoWebApp_Server_v2.Services.SectionService;

namespace TodoWebApp_Server_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        /// <summary>
        /// Create section
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> CreateSection(SectionCreateRequestDto sectionCreateRequestDto)
        {
            var response = await _sectionService.CreateSectionAsync(sectionCreateRequestDto);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Get all Sections by project id
        /// </summary>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSectionByProjectId( long id )
        {
            var response = await _sectionService.GetAllSectionByProjectIdAsync(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }
    }
}
