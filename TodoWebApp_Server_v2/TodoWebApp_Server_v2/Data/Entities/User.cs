using Microsoft.AspNetCore.Identity;

namespace server_todo.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Image { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }
        public List<Project> Projects { get; set; }
    }
}
