namespace server_todo.Data.Entities
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsDeleted { get; set; }

        //For User
        public Guid User_id { get; set; }
        public User User { get; set; }

        //For Color
        public long Color_id { get; set; }
        public Color Color { get; set; }

        public List<Section> Sections { get; set; }
    }
}
