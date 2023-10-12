using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

using Application.Common.DTOs.Movie;
using Application.Responses;

namespace Application.Features.Movies.Requests.Queries;

public class GetMovieListRequest : IRequest<List<MovieDTO>>
{
}

