using AutoMapper;
using Microsoft.AspNetCore.Identity;
using server_todo.Data.Context;
using server_todo.Data.Entities;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.UserDto;
using TodoWebApp_Server_v2.Services.AuthService;
using static System.Net.Mime.MediaTypeNames;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TodoWebApp_Server_v2.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly TodoDbContext _todoDbContext;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public UserService( UserManager<User> userManager, TodoDbContext todoDbContext, IAuthService authService, IMapper mapper, IHostingEnvironment env )
        {
            _userManager = userManager;
            _todoDbContext = todoDbContext;
            _authService = authService;
            _mapper = mapper;
            _env = env;
        }

        public async Task<ResponseObjectDto> UploadAvatarAsync( UploadImageRequestDto uploadImageRequestDto )
        {
            if(uploadImageRequestDto.File == null || uploadImageRequestDto.File.Length == 0) return new ResponseObjectDto("No file selected");

            User user = await _userManager.FindByIdAsync(uploadImageRequestDto.UserId.ToString());
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");

            // Save image to wwwroot
            string fileNameWithExtension = uploadImageRequestDto.File.FileName;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileNameWithExtension) + _authService.RandomString(7);
            string fileNameToStore = string.Concat("avatar--", Convert.ToString(uploadImageRequestDto.UserId), "--", fileNameWithoutExtension, Path.GetExtension(fileNameWithExtension));
            string generateFilepath = Path.Combine("wwwroot", "UserAvatars") + $@"\{fileNameToStore}";

            string[] files = Directory.GetFiles(Path.Combine("wwwroot", "UserAvatars"));
            foreach(string fileName in files)
            {
                if(Regex.IsMatch(fileName, user.Id.ToString()))
                {
                    // Delete the file.
                    File.Delete(fileName);
                }
                
            }


            // Save image file in local folder
            if(!string.IsNullOrEmpty(generateFilepath))
            {
                using(FileStream fileStream = System.IO.File.Create(generateFilepath))
                {
                    uploadImageRequestDto.File.CopyTo(fileStream);
                    fileStream.Flush();
                }

                user.Image = Path.Combine("UserAvatars", fileNameToStore);

                await _todoDbContext.SaveChangesAsync();
            }



            return new ResponseObjectDto("Success", Path.Combine("UserAvatars", fileNameToStore), true);
            //return new ResponseObjectDto("Success", fileName, true);
        }

        public async Task<ResponseObjectDto> DeleteAvatarAsync( Guid id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");

            string filepathExist = Path.Combine("wwwroot") + $@"\{user.Image}";
            if(filepathExist.Contains(user.Id.ToString()))
            {
                File.Delete(filepathExist);
            }

            string pathDefaultAvatar = Path.Combine("UserAvatars", "avatar--default_d1b4ea9d-184b-4187-9134-a31eb7a95741.jpg");

            user.Image = pathDefaultAvatar;

            await _userManager.UpdateAsync(user);

            return new ResponseObjectDto("Delete avatar Success", pathDefaultAvatar, true);      
        }

        public async Task<ResponseObjectDto> UpdateEmailAsync( UpdateEmailRequestDto updateEmailRequestDto)
        {

            var emailExisted = await _userManager.FindByEmailAsync(updateEmailRequestDto.newEmail);
            if(emailExisted != null) return new ResponseObjectDto("Email alrady exist", true);

            User user = await _userManager.FindByIdAsync(updateEmailRequestDto.Id.ToString());

            if(user == null) return new ResponseObjectDto("Cannot find user with that id");
           
            if(string.IsNullOrEmpty(updateEmailRequestDto.newEmail)) return new ResponseObjectDto("Invalid email", true);

            var validatedPassword = await _userManager.CheckPasswordAsync(user, updateEmailRequestDto.Password);
            if(validatedPassword)
            {
                string token = await _userManager.GenerateChangeEmailTokenAsync(user, updateEmailRequestDto.newEmail);
                var changeEmail = await _userManager.ChangeEmailAsync(user, updateEmailRequestDto.newEmail, token);
                if(changeEmail.Succeeded) return new ResponseObjectDto("Updated new Email", user.Email, true);
            }
            
            return new ResponseObjectDto("Incorrect password", true);
        }

        public async Task<ResponseObjectDto> UpdatePasswordAsync( UpdatePasswordRequestDto updatePasswordRequestDto )
        {
            User user = await _userManager.FindByIdAsync(updatePasswordRequestDto.Id.ToString());
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");

            if(string.IsNullOrEmpty(updatePasswordRequestDto.currentPassword)) return new ResponseObjectDto("Invalid current password", true);
            if(string.IsNullOrEmpty(updatePasswordRequestDto.newPassword)) return new ResponseObjectDto("Invalid new password", true);

            var updatedPassword = await _userManager.ChangePasswordAsync(user, updatePasswordRequestDto.currentPassword, updatePasswordRequestDto.newPassword);

            if(updatedPassword.Succeeded) return new ResponseObjectDto("Updated new Password", "", true);

            return new ResponseObjectDto("Incorrect password", true);
        }

        public async Task<ResponseObjectDto> UpdateUserNameAsync( UpdateUserNameRequestDto updateUserNameRequest )
        {
            User user = await _userManager.FindByIdAsync(updateUserNameRequest.Id.ToString());
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");

            if(string.IsNullOrEmpty(updateUserNameRequest.UserName)) return new ResponseObjectDto("Invalid user name", true);

            var updatedUserName = await _userManager.SetUserNameAsync(user, updateUserNameRequest.UserName);

            if(updatedUserName.Succeeded) return new ResponseObjectDto("Updated User name", user.UserName, true);

            return new ResponseObjectDto("Update User name failure");

        }

        public async Task<ResponseObjectDto> UpdateThemeAsync( UpdateThemeRequestDto updateThemeRequestDto )
        {
            User user = await _userManager.FindByIdAsync(updateThemeRequestDto.Id.ToString());
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");

            if(string.IsNullOrEmpty(updateThemeRequestDto.Theme)) return new ResponseObjectDto("Invalid theme value", true);


            user.Theme = updateThemeRequestDto.Theme;

            var updatedTheme = await _userManager.UpdateAsync(user);

            if(updatedTheme.Succeeded) return new ResponseObjectDto("Updated Theme", user.Theme, true);

            return new ResponseObjectDto("Update Theme failure");

        }

        public async Task<ResponseObjectDto> UpdateLanguageAsync( UpdateLanguageRequestDto updateLanguageRequestDto )
        {
            User user = await _userManager.FindByIdAsync(updateLanguageRequestDto.Id.ToString());
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");

            if(string.IsNullOrEmpty(updateLanguageRequestDto.Language)) return new ResponseObjectDto("Invalid Language value", true);


            user.Language = updateLanguageRequestDto.Language;

            var updatedLanguage = await _userManager.UpdateAsync(user);

            if(updatedLanguage.Succeeded) return new ResponseObjectDto("Update Language", user.Language, true);

            return new ResponseObjectDto("Update Language failure");
        }

        public async Task<ResponseObjectDto> DeleteAccountAsync( Guid id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            if(user == null) return new ResponseObjectDto("Cannot find user with that id");

            var deletedUser = await _userManager.DeleteAsync(user);

            if(deletedUser.Succeeded) return new ResponseObjectDto("Deleted user", "", true);

            return new ResponseObjectDto("Delete User failure");
        }

        
    }
}
