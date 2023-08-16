namespace TodoWebApp_Server_v2.Dtos.UserDto
{
    public class UploadImageRequestDto
    {
        public Guid UserId { get; set; }
        public IFormFile File { get; set; }

    }
}
