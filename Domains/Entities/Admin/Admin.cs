using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string JobDescription { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        public DateTime RegisterTime { get; set; } = DateTime.Now;
    }
}
