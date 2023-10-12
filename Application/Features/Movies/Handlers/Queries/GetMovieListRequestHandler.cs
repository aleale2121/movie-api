using AutoMapper;

using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Application.Common.DTOs.Movie;
using Application.Common.DTOs.Movie.Validators;
using Application.Common.Exceptions;
using Application.Features.Movies.Requests.Queries;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Movies.Handlers.Queries;

public class GetMovieListRequestHandler : IRequestHandler<GetMovieListRequest, List<MovieDTO>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMovieListRequestHandler(IMovieRepository movieRepository,
            IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<List<MovieDTO>> Handle(GetMovieListRequest request, CancellationToken cancellationToken)
    {
        var movieDTOs = new List<MovieDTO>();

        var movies = await _movieRepository.GetAll();
        movieDTOs = _mapper.Map<List<MovieDTO>>(movies.ToList());
        return movieDTOs;
    }
}

