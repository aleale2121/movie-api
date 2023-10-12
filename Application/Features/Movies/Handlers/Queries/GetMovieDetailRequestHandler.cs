using AutoMapper;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Movie;
using Application.Common.DTOs.Movie.Validators;
using Application.Common.Exceptions;
using Application.Features.Movies.Requests.Queries;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Movies.Handlers.Queries;

public class GetMovieDetailRequestHandler : IRequestHandler<GetMovieDetailRequest, MovieDTO>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMovieDetailRequestHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<MovieDTO> Handle(GetMovieDetailRequest request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.Get(request.Id);
        return _mapper.Map<MovieDTO>(movie);
    }
}

