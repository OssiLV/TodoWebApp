namespace TodoWebApp_Server_v2.Dtos.TaskTodoDto
{
    public class TaskTodoCreateRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public string Due_Date { get; set; }
        public string CreatedAt { get; set; }
        public long Project_id { get; set; }
        public long Section_id { get; set; }
        public string? SectionName { get; set; }

    }
}
