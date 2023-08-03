using TodoWebApp_Server_v2.Dtos.ColorDto;

namespace TodoWebApp_Server_v2.Dtos.ProjectDto
{
    public class ListProjectResponseDto
    {
        public ProjectResponseDto ProjectResponseDto { get; set; }
        public ColorResponseDto ColorResponseDto { get; set; }
    }
}
