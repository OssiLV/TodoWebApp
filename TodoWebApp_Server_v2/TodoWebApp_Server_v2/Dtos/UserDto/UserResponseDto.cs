namespace TodoWebApp_Server_v2.Dtos.UserDto
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }
        public string Image { get; set; }
    }
}
