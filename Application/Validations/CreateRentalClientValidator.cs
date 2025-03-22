using Application.Dtos.Request.RequestClient;
using FluentValidation;
using Infrastructure.DataAccess;

namespace Application.Validations
{
    public class CreateRentalClientValidator : AbstractValidator<CreateRentalClientRequest>
    {
        private readonly AppDbContext _context;

        public CreateRentalClientValidator(AppDbContext context)
        {
            _context = context;


            RuleFor(d => d.Name).NotEmpty().WithMessage("Campo nome é obrigatório");
            RuleFor(d => d.Email).NotEmpty().WithMessage("Campo email é obrigatório")
                .EmailAddress().WithMessage("Digite um email válido");
                
            RuleFor(d => d.Cpf).NotEmpty().WithMessage("Campo cpf é obrigatório");
        
        }
    }
}
