using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.DTOs.Cinema;

using Application.Common.DTOs.Cinema;
using Application.Contracts.Persistence;

namespace Application.Common.DTOs.Cinema.Validators;

public class ICinemaDtoValidator : AbstractValidator<ICinemaDTO>
{

    public ICinemaDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 100 characters.");

        RuleFor(p => p.Location)
            .NotEmpty().WithMessage("{PropertyName} is required.");
        
        RuleFor(p => p.Address)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Phone)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Matches(@"^\+?(\d{1,4}[-\s]?)?(\d{9,14})$") 
            .WithMessage("{PropertyName} is not a valid phone number.");
    }
}

