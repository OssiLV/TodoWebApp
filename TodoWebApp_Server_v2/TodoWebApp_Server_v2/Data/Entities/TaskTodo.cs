using System.Transactions;

namespace server_todo.Data.Entities
{
    public class TaskTodo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public string Due_Date { get; set; }
        public string CreatedAt { get; set; }


        public long Section_id { get; set; }

        public List<SubTaskTodo> SubTaskTodos { get; set; }
        public Section Section { get; set; }

    }
}
