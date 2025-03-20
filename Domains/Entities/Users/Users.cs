namespace Domain.Entities.Users
{
    public class Users
    {
        public Users(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime RegisterTime { get; set; } = DateTime.Now;
    }
}
