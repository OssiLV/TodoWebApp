namespace server_todo.Data.Entities
{
    public class SubTaskTodo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public string Due_Date { get; set; }
        public string CreatedAt { get; set; }


        public long TaskTodo_id { get; set; }

        public TaskTodo TaskTodo { get; set; }
    }
}
