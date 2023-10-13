using AutoMapper;
using Application.Contracts.Persistence;
using Application.Common.DTOs;

using Application.Common.DTOs.Cinema;
using Application.Features.Cinemas.Handlers.Queries;
using Application.Features.Cinemas.Requests.Queries;
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

public class GetCinemaListRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICinemaRepository> _mockRepo;
    private readonly  GetCinemaListRequestHandler _handler;
    public GetCinemaListRequestHandlerTests()
    {
        _mockRepo = MockCinemaRepository.GetCinemaRepository();

        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
       _handler = new GetCinemaListRequestHandler(_mockRepo.Object, _mapper);

        
    }

    [Fact]
    public async Task GetCinemaListTest()
    {
        var result = await _handler.Handle(new GetCinemaListRequest(), CancellationToken.None);
        result.ShouldBeOfType<List<CinemaDTO>>();
        result.Count.ShouldBe(4);
    }
}

