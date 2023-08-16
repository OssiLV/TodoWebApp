    using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using server_todo.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoWebApp_Server_v2.Dtos;
using TodoWebApp_Server_v2.Dtos.UserDto;

namespace TodoWebApp_Server_v2.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration configuration,
            IMapper mapper )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = configuration;
            _mapper = mapper;
        }

        private string GenerateAccessToken( List<Claim> claims )
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtBearer:securityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                _config["JwtBearer:Issuer"],
                _config["JwtBearer:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return accessToken;
        }
        public string RandomString( int length )
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<ResponseObjectDto> AuthenticateAsync( LoginRequestDto loginRequestDto )
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if(user == null) return new ResponseObjectDto("Email is not exist!!");

            var result = await _signInManager.PasswordSignInAsync(user, loginRequestDto.Password, true, true);
            if(!result.Succeeded) return new ResponseObjectDto("Incorrect Password!!");

            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            claims.AddRange(userClaims);
            foreach(var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if(role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach(var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            var accessToken = GenerateAccessToken(claims);


            
            var userResponse = _mapper.Map<UserResponseDto>(user);


            
            return new ResponseObjectDto("Log In Successfully", new { accessToken, userResponse }, true);
        }

        public async Task<ResponseObjectDto> SignUpAsync( RegisterRequestDto registerRequestDto )
        {
            var user = await _userManager.FindByEmailAsync(registerRequestDto.Email);

            if(user != null)
            {
                return new ResponseObjectDto("Email already exists");
            }



            user = new User()
            {
                UserName = RandomString(6),
                Email = registerRequestDto.Email,
                EmailConfirmed = false,
                Theme = "Primary",
                Language = "en",
                Image = Path.Combine("UserAvatars", "avatar--default_d1b4ea9d-184b-4187-9134-a31eb7a95741.jpg")
            };

            var result = await _userManager.CreateAsync(user, registerRequestDto.Password);

            if(result.Succeeded)
            {
                
                return new ResponseObjectDto("Register Successfully", true);
            }

            return new ResponseObjectDto("Cannot register!");
        }
    }
}
