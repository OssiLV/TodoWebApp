namespace TodoWebApp_Server_v2.Dtos.TaskTodoDto
{
    public class TaskTodoResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public string Due_Date { get; set; }
        public string CreatedAt { get; set; }
        public long Section_id { get; set; }
    }
}
