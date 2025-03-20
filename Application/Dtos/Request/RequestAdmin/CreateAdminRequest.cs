namespace Application.Dtos.Request.RequestAdmin
{
    public class CreateAdminRequest
    {
        public string Name { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
