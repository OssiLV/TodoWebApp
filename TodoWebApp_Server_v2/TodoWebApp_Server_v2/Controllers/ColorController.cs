using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp_Server_v2.Dtos.ColorDto;
using TodoWebApp_Server_v2.Services.ColorService;

namespace TodoWebApp_Server_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        /// <summary>
        /// Get all Color
        /// </summary>
        [HttpGet]
        public IActionResult GetAllColor()
        {
            var response = _colorService.GetAllColors();
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Get color by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColorById( [FromRoute] long id )
        {
            var response = await _colorService.GetColorByIdAsync(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Create a color
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateColor([FromBody]ColorCreateResquestDto colorCreateResquestDto)
        {
            var response = await _colorService.CreateColorAsync(colorCreateResquestDto);

            return Ok(response);
        }

        /// <summary>
        /// Update a color by id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColorById( [FromRoute] long id, [FromBody] ColorUpdateRequestDto colorUpdateRequestDto)
        {
            var response = await _colorService.UpdateColorByIdAsync(id, colorUpdateRequestDto);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Delete a color
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColorById( [FromRoute] long id )
        {
            var response = await _colorService.DeleteColorByIdAsync(id);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }
    }
}
