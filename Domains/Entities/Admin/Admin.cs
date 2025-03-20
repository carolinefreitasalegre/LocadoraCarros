namespace Domain.Entities.Admin
{
    public class Admin
    {
        public Admin(string name, string jobDescription, string email, string password)
        {
            Name = name;
            JobDescription = jobDescription;
            Email = email;
            Password = password;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterTime { get; set; } = DateTime.Now;
    }
}
