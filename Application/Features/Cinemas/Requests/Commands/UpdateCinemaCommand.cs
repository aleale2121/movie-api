using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.DTOs.Cinema;
using Application.Responses;

namespace Application.Features.Cinemas.Requests.Commands;

public class UpdateCinemaCommand : IRequest<BaseCommandResponse>
{
    public UpdateCinemaDTO CinemaDto { get; set; }
}

