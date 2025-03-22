namespace Application.Dtos.Response.ResponseClient
{
    public class CreateRentalClientResponse
    {
        public CreateRentalClientResponse(string name, string email, string cpf)
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
