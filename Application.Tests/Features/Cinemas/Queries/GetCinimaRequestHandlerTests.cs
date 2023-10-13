using AutoMapper;
using Application.Contracts.Persistence;
using Application.Common.DTOs;
using Application.Common.DTOs.Cinema;

using Application.Features.Cinemas.Handlers.Commands;
using Application.Features.Cinemas.Handlers.Queries;
using Application.Features.Cinemas.Requests.Commands;
using Application.Features.Cinemas.Requests.Queries;
using Application.Responses;

using Application.Profiles;
using Application.Tests.Mocks;
using Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Cinemas.Queries;

public class GetCinemaRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICinemaRepository> _mockRepo;
    private readonly  GetCinemaDetailRequestHandler _handler;
    public GetCinemaRequestHandlerTests()
    {
        _mockRepo = MockCinemaRepository.GetCinemaRepository();

        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
       _handler = new GetCinemaDetailRequestHandler(_mockRepo.Object, _mapper);

        
    }

    [Fact]
    public async Task Valid_GetCinemaTest()
    {
        // var result = await _handler.Handle(new GetCinemaDetailRequest(){Id=1}, CancellationToken.None);

        // result.ShouldBeOfType<BaseCommandResponse>();
        // result.ShouldBeOfType<CinemaDTO>();
    }

}

