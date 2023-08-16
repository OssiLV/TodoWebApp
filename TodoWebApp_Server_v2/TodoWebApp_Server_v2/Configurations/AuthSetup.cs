using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TodoWebApp_Server_v2.Configurations
{
    public static class AuthSetup
    {
        public static IServiceCollection AddAuthSetup( this IServiceCollection services, IConfiguration configuration )
        {
            string token = configuration.GetValue<string>("JwtBearer:securityKey");
            string issuer = configuration.GetValue<string>("JwtBearer:Issuer");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token)),
                };
            });

            services.AddCors(opt => opt
                .AddPolicy("Product",
                builder =>
                builder
                    //.WithOrigins("https://dev--ossilvtodoapp.netlify.app/")
                    .AllowAnyOrigin()
                    .WithMethods("GET", "PUT", "POST", "DELETE")
                    .AllowAnyHeader()
                    )
            );

            services.AddCors(opt => opt
               .AddPolicy("Dev",
               builder =>
               builder
                   .WithOrigins("http://localhost:3000")
                   .WithMethods("GET", "PUT", "POST", "DELETE")
                   .AllowAnyHeader()
                   )
           );

            return services;
        }
    }
}
