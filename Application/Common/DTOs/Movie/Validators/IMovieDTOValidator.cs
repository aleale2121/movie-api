using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.DTOs.Movie;

using Application.Common.DTOs.Movie;
using Application.Contracts.Persistence;

namespace Application.DTOs.Movie.Validators;


public class IMovieDtoValidator : AbstractValidator<IMovieDTO>
{

    public IMovieDtoValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 100 characters.");

        RuleFor(p => p.Genre)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.ReleaseYear)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    
    }


}

