using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp_Server_v2.Dtos.UserDto;
using TodoWebApp_Server_v2.Services.AuthService;

namespace TodoWebApp_Server_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController( IAuthService authService )
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate( [FromBody] LoginRequestDto loginRequestDto )
        {
            var user = await _authService.AuthenticateAsync(loginRequestDto);

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp( [FromBody] RegisterRequestDto registerRequestDto )
        {
            var user = await _authService.SignUpAsync(registerRequestDto);

            return Ok(user);
        }
    }
}
