namespace Application.Dtos.Request.RequestClient
{
    public class CreateRentalClientRequest
    {
        public CreateRentalClientRequest(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}
