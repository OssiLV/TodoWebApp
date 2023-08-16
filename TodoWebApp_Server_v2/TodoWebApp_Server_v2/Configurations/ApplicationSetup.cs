using TodoWebApp_Server_v2.Services.AuthService;
using TodoWebApp_Server_v2.Services.ColorService;
using TodoWebApp_Server_v2.Services.ProjectService;
using TodoWebApp_Server_v2.Services.SectionService;
using TodoWebApp_Server_v2.Services.TaskTodoService;
using TodoWebApp_Server_v2.Services.UserService;

namespace TodoWebApp_Server_v2.Configurations
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
        {
            services.AddTransient<ITaskTodoService, TaskTodoService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
