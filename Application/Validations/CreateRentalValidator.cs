using Application.Dtos.Request.RequestRental;
using FluentValidation;
using Infrastructure.DataAccess;

namespace Application.Validations
{
    public class CreateRentalValidator : AbstractValidator<RentalRequest>
    {
        private readonly AppDbContext _context;

        public CreateRentalValidator(AppDbContext context)
        {
            _context = context;



            RuleFor(c => c.CarroId).NotEmpty().WithMessage("Campo não pode estar em branco.");
            RuleFor(c => c.ClienteId).NotEmpty().WithMessage("Campo não pode estar em branco.");
            RuleFor(c => c.DataFimPrevista).NotEmpty().WithMessage("Campo não pode estar em branco.");
            RuleFor(c => c.DataFimReal).NotEmpty().WithMessage("Campo não pode estar em branco.");
            RuleFor(c => c.PrecoDiaria).NotEmpty().WithMessage("Campo não pode estar em branco.")
                .GreaterThan(0).WithMessage("O preço da diária deve ser maior que zero.");

            RuleFor(c => c.DataInicio).NotEmpty().WithMessage("Campo não pode estar em branco.");
                
            
            RuleFor(c => c.DiasAlugados).NotEmpty().WithMessage("Campo não pode estar em branco.")
                  .GreaterThan(0).WithMessage("O número de dias deve ser maior que zero."); ;
        }
    }
}
