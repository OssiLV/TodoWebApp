namespace TodoWebApp_Server_v2.Dtos.UserDto
{
    public class UpdateEmailRequestDto
    {
        public Guid Id { get; set; }
        public string newEmail { get; set; }
        public string Password { get; set; }
    }
}
