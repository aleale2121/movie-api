using AutoMapper;

using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Application.Common.DTOs.Cinema;
using Application.Common.DTOs.Cinema.Validators;
using Application.Common.Exceptions;
using Application.Features.Cinemas.Requests.Queries;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Cinemas.Handlers.Queries;

public class GetCinemaListRequestHandler : IRequestHandler<GetCinemaListRequest, List<CinemaDTO>>
{
    private readonly ICinemaRepository _cinemaRepository;
    private readonly IMapper _mapper;

    public GetCinemaListRequestHandler(ICinemaRepository cinemaRepository,
            IMapper mapper)
    {
        _cinemaRepository = cinemaRepository;
        _mapper = mapper;
    }

    public async Task<List<CinemaDTO>> Handle(GetCinemaListRequest request, CancellationToken cancellationToken)
    {
        var cinemaDTOs = new List<CinemaDTO>();

        var cinemas = await _cinemaRepository.GetAll();
        cinemaDTOs = _mapper.Map<List<CinemaDTO>>(cinemas.ToList());
        return cinemaDTOs;
    }
}

