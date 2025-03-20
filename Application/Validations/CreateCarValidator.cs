using Application.Dtos.Request.CreateCarRequest;
using FluentValidation;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Validations
{
    public class CreateCarValidator : AbstractValidator<CreateCarRequest>
    {
        private readonly AppDbContext _context;

        public CreateCarValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(c => c.Model)
           .NotEmpty().WithMessage("O modelo do carro não pode estar em branco.");

            RuleFor(c => c.Year)
                .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("O ano deve estar entre 1900 e o ano atual.");

            RuleFor(c => c.Dors)
                .GreaterThan(0).WithMessage("O número de portas deve ser maior que zero.");

            RuleFor(c => c.Marca)
                .NotEmpty().WithMessage("A marca do carro não pode estar em branco.");

            RuleFor(c => c.Placa)
                 .Matches("^[A-Z]{3}-\\d{4}$|^[A-Z]{3}\\d[A-Z]\\d{2}$")
                 .WithMessage("A placa deve estar no formato válido (ex: ABC-1234 ou ABC1D23).")
                 .MustAsync(OnlyId)
                 .WithMessage("Placa já registrada em outro automóvel");


            RuleFor(c => c.Cor)
                .NotEmpty().WithMessage("A cor do carro não pode estar em branco.");

            RuleFor(c => c.Quilometragem)
                .GreaterThanOrEqualTo(0).WithMessage("A quilometragem não pode ser negativa.");

            RuleFor(c => c.Cambio)
                .NotEmpty().WithMessage("O tipo de câmbio não pode estar em branco.");

            RuleFor(c => c.Combustivel)
                .NotEmpty().WithMessage("O tipo de combustível não pode estar em branco.");

            RuleFor(c => c.Capacidade)
                .GreaterThan(0).WithMessage("A capacidade do veículo deve ser maior que zero.");

            RuleFor(c => c.PrecoDiaria)
                .GreaterThan(0).WithMessage("O preço da diária deve ser maior que zero.");

            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("O status do carro não pode estar em branco.");

            RuleFor(c => c.DataUltimaManutencao)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data da última manutenção não pode ser futura.");

        }

        private async Task<bool> OnlyId(string placa, CancellationToken token)
        {
            return !await _context.carros.AnyAsync(c => c.Placa == placa, token);

        }

        public CreateCarValidator()
        {
        }

    }
}
