using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.UserDto;
using TodoWebApp_Server_v2.Services.UserService;

namespace TodoWebApp_Server_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController( IUserService userService )
        {
            _userService = userService;
        }

        /// <summary>
        ///  Upload avatar with user id
        /// </summary>
        [HttpPost("uploadAvatar")]
        public async Task<IActionResult> HandleUploadAvatar( [FromForm] UploadImageRequestDto uploadImageRequestDto )
        {

            var response = await _userService.UploadAvatarAsync(uploadImageRequestDto);

            if(response.IsSuccess()) return Ok(response);
            return Ok(response);
        }
        /// <summary>
        ///  Update password with user id
        /// </summary>
        [HttpPut("password")]
        public async Task<ActionResult> UpdatePassword( [FromBody] UpdatePasswordRequestDto updatePasswordRequestDto )
        {
            var response = await _userService.UpdatePasswordAsync(updatePasswordRequestDto);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        ///  Update email with user id
        /// </summary>
        [HttpPut("email")]
        public async Task<ActionResult> UpdateEmail( [FromBody] UpdateEmailRequestDto updateEmailRequestDto )
        {
            var response = await _userService.UpdateEmailAsync(updateEmailRequestDto);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        ///  Update User name with user id
        /// </summary>
        [HttpPut("username")]
        public async Task<ActionResult> UpdateUserName( [FromBody] UpdateUserNameRequestDto updateUserNameRequest )
        {
            var response = await _userService.UpdateUserNameAsync(updateUserNameRequest);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        ///  Update Theme with user id
        /// </summary>
        [HttpPut("theme")]
        public async Task<ActionResult> UpdateTheme( [FromBody] UpdateThemeRequestDto updateThemeRequestDto )
        {
            var response = await _userService.UpdateThemeAsync(updateThemeRequestDto);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        ///  Update Language with user id
        /// </summary>
        [HttpPut("language")]
        public async Task<ActionResult> UpdateLanguage( [FromBody] UpdateLanguageRequestDto updateLanguageRequestDto )
        {
            var response = await _userService.UpdateLanguageAsync(updateLanguageRequestDto);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        ///  Delete Account with user id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount( [FromRoute] Guid id )
        {
            var response = await _userService.DeleteAccountAsync(id);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        ///  Delete User image with user id
        /// </summary>
        [HttpPut("defaultAvatar/{id}")]
        public async Task<ActionResult> DeleteAvatar( [FromRoute] Guid id )
        {
            var response = await _userService.DeleteAvatarAsync(id);

            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }
    }
}
