using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.UserDto;

namespace TodoWebApp_Server_v2.Services.UserService
{
    public interface IUserService
    {
        Task<ResponseObjectDto> UploadAvatarAsync( UploadImageRequestDto uploadImageRequestDto);
        Task<ResponseObjectDto> DeleteAvatarAsync(Guid id);
        Task<ResponseObjectDto> UpdateUserNameAsync( UpdateUserNameRequestDto updateUserNameRequest);
        Task<ResponseObjectDto> UpdateThemeAsync( UpdateThemeRequestDto updateThemeRequestDto);
        Task<ResponseObjectDto> UpdateLanguageAsync( UpdateLanguageRequestDto updateLanguageRequestDto);
        Task<ResponseObjectDto> UpdateEmailAsync( UpdateEmailRequestDto updateEmailRequestDto );
        Task<ResponseObjectDto> UpdatePasswordAsync( UpdatePasswordRequestDto updatePasswordRequestDto);
        Task<ResponseObjectDto> DeleteAccountAsync( Guid id );

    }
}
