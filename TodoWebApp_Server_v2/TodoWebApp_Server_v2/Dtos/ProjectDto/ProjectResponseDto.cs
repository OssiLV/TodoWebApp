using server_todo.Data.Entities;
using TodoWebApp_Server_v2.Dtos.ColorDto;

namespace TodoWebApp_Server_v2.Dtos.ProjectDto
{
    public class ProjectResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsDeleted { get; set; }

        public ColorResponseDto Color { get; set; }
    }
}
