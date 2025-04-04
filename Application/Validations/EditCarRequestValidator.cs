﻿using FluentValidation;
using Infrastructure.DataAccess;

namespace Application.Validations
{
    public class EditCarRequestValidator : AbstractValidator<EditCarRequest>
    {

        public EditCarRequestValidator()
        {
            
            Include(new CreateCarValidator());

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O Id é obrigatório.");

            RuleFor(c => c.Placa)
                .Empty().WithMessage("A Placa não pode ser informada no EditRequest.");
        }
    }
}
