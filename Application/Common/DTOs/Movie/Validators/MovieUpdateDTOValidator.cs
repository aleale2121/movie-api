using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.DTOs.Movie;

using Application.Common.DTOs.Movie;
using Application.Contracts.Persistence;

namespace Application.Common.DTOs.Movie.Validators;

public class UpdateMovieDtoValidator : AbstractValidator<UpdateMovieDTO>
{

    public  UpdateMovieDtoValidator()
    {
        Include(new IMovieDtoValidator());
    }
}

