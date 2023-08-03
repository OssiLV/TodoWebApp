using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server_todo.Data.Context;
using server_todo.Data.Entities;

namespace TodoWebApp_Server_v2.Configurations
{
    public static class PersistanceSetup
    {
        public static IServiceCollection AddPersistanceSetup( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlServer"));
            });

            services.AddIdentity<User, AppRole>()
                .AddEntityFrameworkStores<TodoDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
            });

            return services;
        }
    }
}
