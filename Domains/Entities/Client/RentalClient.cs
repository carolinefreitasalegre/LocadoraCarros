using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.RentalClient
{
    public class RentalClient
    {
        public RentalClient(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
        }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50), EmailAddress]
        public string Email {  get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        public DateTime RegisterTime { get; set; } = DateTime.Now;   
    }
}
