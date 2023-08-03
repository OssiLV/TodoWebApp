namespace TodoWebApp_Server_v2.Dtos.ProjectDto
{
    public class ProjectCreateRequestDto
    {
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsDeleted { get; set; }
        public long Color_id { get; set; }
        public Guid User_id { get; set; }
    }
}
