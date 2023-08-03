using Microsoft.AspNetCore.Identity;

namespace server_todo.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public List<Project> Projects { get; set; }
    }
}
