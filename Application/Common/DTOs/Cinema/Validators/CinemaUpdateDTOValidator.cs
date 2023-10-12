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

public class UpdateCinemaDtoValidator : AbstractValidator<UpdateCinemaDTO>
{

    public  UpdateCinemaDtoValidator()
    {
        Include(new ICinemaDtoValidator());
    }
}

