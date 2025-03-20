using FluentValidation;
using Infrastructure.DataAccess;

namespace Application.Validations
{
    public class EditRequestValidator : AbstractValidator<EditCarRequest>
    {

        public EditRequestValidator()
        {
            
            Include(new CreateCarValidator());

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O Id é obrigatório.");

            RuleFor(c => c.Placa)
                .Empty().WithMessage("A Placa não pode ser informada no EditRequest.");
        }
    }
}
