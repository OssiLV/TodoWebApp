namespace server_todo.Data.Entities
{
    public class Color
    {
        public long Id { get; set; }
        public string TailwindBgHexCode { get; set; }
        public string Name { get; set; }

        public List<Project> Projects { get; set; }
    }
}
