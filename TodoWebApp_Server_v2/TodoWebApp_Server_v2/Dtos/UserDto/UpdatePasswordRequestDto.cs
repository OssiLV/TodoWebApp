namespace TodoWebApp_Server_v2.Dtos.UserDto
{
    public class UpdatePasswordRequestDto
    {
        public Guid Id { get; set; }
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }
}
