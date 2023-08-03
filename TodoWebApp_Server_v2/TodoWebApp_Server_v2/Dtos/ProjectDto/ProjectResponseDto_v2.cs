using TodoWebApp_Server_v2.Dtos.ColorDto;
using TodoWebApp_Server_v2.Dtos.SectionDto;

namespace TodoWebApp_Server_v2.Dtos.ProjectDto
{
    public class ProjectResponseDto_v2
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsDeleted { get; set; }

        public ColorResponseDto Color { get; set; }
        public List<SectionResponseDto> Sections { get; set; }
    }
}
