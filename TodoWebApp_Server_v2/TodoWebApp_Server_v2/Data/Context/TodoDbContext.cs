using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using server_todo.Data.Configs;
using server_todo.Data.Entities;

namespace server_todo.Data.Context
{
    public class TodoDbContext : IdentityDbContext<User, AppRole, Guid>
    {
        public TodoDbContext( DbContextOptions options ) : base(options) { }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.ApplyConfiguration(new ProjectConfig());
            builder.ApplyConfiguration(new SectionConfig());
            builder.ApplyConfiguration(new TaskTodoConfig());
            builder.ApplyConfiguration(new SubTaskTodoConfig());
            builder.ApplyConfiguration(new ColorConfig());


            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

           
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<TaskTodo> TaskTodos { get; set; }
        public DbSet<SubTaskTodo> SubTaskTodos { get; set; }
    }
}
