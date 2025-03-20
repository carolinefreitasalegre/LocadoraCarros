using Application.Dtos.Request.RequestAdmin;
using FluentValidation;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Validations
{
    public class CreateAdminValidator : AbstractValidator<CreateAdminRequest>
    {
        private readonly AppDbContext _context;
        public CreateAdminValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(a => a.Name).NotEmpty().WithMessage("Campo nome não pode estar e branco");

            RuleFor(a => a.JobDescription).NotEmpty().WithMessage("Campo cargo não pode estar e branco");

            RuleFor(a => a.Email).EmailAddress().NotEmpty().WithMessage("Campo nome email pode estar e branco")
                .MustAsync(OnlyEmail).WithMessage("Email já cadastrado.");

            RuleFor(a => a.Password).NotEmpty().WithMessage("Campo senha não pode estar e branco")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .Matches(@"[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches(@"[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches(@"\d").WithMessage("A senha deve conter pelo menos um número.")
                .Matches(@"[\W]").WithMessage("A senha deve conter pelo menos um caractere especial."); ;

        }

        public async Task<bool> OnlyEmail(string email, CancellationToken token)
        {
            return !await _context.admin.AnyAsync(e => e.Email == email);
        }
    }
}
