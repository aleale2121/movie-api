using AutoMapper;
using Application.Contracts.Persistence;
using Application.Common.DTOs.Cinema;
using Application.Common.Exceptions;
using Application.Features.Cinemas.Handlers.Commands;
using Application.Features.Cinemas.Handlers.Queries;
using Application.Features.Cinemas.Requests.Commands;
using Application.Features.Cinemas.Requests.Queries;
using Application.Profiles;
using Application.Responses;
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

namespace Application.Tests.Cinemas.Commands;

public class CreateCinemaCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly CreateCinemaDTO _cinemaDto;
    private readonly CreateCinemaCommandHandler _handler;

    public CreateCinemaCommandHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetUnitOfWork();
        
        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new CreateCinemaCommandHandler(_mockUow.Object, _mapper);

        _cinemaDto = new  CreateCinemaDTO{
            Name = "Cinema 5",
            Location = "Location 5",
            Address = "Address 5",
            Phone = "+123-4567890123",
        };
    }

    [Fact]
    public async Task Valid_Cinema_Added()
    {
        var result = await _handler.Handle(new CreateCinemaCommand() { CinemaDto = _cinemaDto }, CancellationToken.None);

        var cinemas = await _mockUow.Object.CinemaRepository.GetAll();

        result.ShouldBeOfType<BaseCommandResponse>();

        cinemas.Count.ShouldBe(5);
    }

    [Fact]
    public async Task InValid_Cinema_Added()
    {
        _cinemaDto.Name = "";

        var result = await _handler.Handle(new CreateCinemaCommand() { CinemaDto = _cinemaDto }, CancellationToken.None);

        var cinemas = await _mockUow.Object.CinemaRepository.GetAll();
        
        cinemas.Count.ShouldBe(4);

        result.ShouldBeOfType<BaseCommandResponse>();
        
    }
}
