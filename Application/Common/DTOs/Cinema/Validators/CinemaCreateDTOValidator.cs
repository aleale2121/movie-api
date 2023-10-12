using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.DTOs.Cinema;
using Application.Contracts.Persistence;

namespace Application.Common.DTOs.Cinema.Validators;

public class CreateCinemaDtoValidator : AbstractValidator<CreateCinemaDTO>
{

    public CreateCinemaDtoValidator()
    {
        Include(new ICinemaDtoValidator());
    }
}

