namespace TodoWebApp_Server_v2.Dtos.TaskTodoDto
{
    public class TaskTodoRescheduleRequestDto
    {
        public long[] Tasks_id { get; set; }
        public string DueDate { get; set; }
    }
}
