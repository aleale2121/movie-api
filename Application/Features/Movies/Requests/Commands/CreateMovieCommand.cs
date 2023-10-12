using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.DTOs.Movie;
using Application.Responses;

namespace Application.Features.Movies.Requests.Commands;

public class CreateMovieCommand : IRequest<BaseCommandResponse>
{
    public CreateMovieDTO MovieDto { get; set; }
}

