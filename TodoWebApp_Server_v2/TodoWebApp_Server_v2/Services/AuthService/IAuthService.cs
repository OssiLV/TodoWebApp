using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.UserDto;

namespace TodoWebApp_Server_v2.Services.AuthService
{
    public interface IAuthService
    {
        Task<ResponseObjectDto> Authenticate( LoginRequestDto loginRequestDto );
        Task<ResponseObjectDto> SignUp( RegisterRequestDto registerRequestDto );
    }
}
