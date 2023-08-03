namespace server_todo.Data.Entities
{
    public class Section
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long Project_id { get; set; }

        public Project Project { get; set; }
        public List<TaskTodo> TaskTodos { get; set; }
    }
}
