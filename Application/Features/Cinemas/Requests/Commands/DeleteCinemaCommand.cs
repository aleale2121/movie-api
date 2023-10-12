using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.DTOs.Movie;
using Application.Responses;

namespace Application.Features.Cinemas.Requests.Commands;

public class DeleteCinemaCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
}
