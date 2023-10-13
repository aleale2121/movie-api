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

public class UpdateCinemaCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly UpdateCinemaDTO _cinemaDto;
    private readonly UpdateCinemaCommandHandler _handler;

    public UpdateCinemaCommandHandlerTests()
    {
        _mockUow = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new UpdateCinemaCommandHandler(_mockUow.Object, _mapper);

        _cinemaDto = new UpdateCinemaDTO
        {
            Id = 1,
            Name = "Cinema 5 U",
            Location = "Location 5 U",
            Address = "Address 5 U",
            Phone = "Phone 5 U",
        };
    }

    [Fact]
    public async Task Valid_Cinema_Updated()
    {
        var result = await _handler.Handle(new UpdateCinemaCommand() { CinemaDto = _cinemaDto }, CancellationToken.None);

        var cinemas = await _mockUow.Object.CinemaRepository.GetAll();

        result.ShouldBeOfType<BaseCommandResponse>();
        cinemas.Count.ShouldBe(4);
        
    }

    [Fact]
    public async Task InValid_Cinema_Updated()
    {
        _cinemaDto.Name = ""; 

        var result = await _handler.Handle(new UpdateCinemaCommand() { CinemaDto = _cinemaDto }, CancellationToken.None);

        result.ShouldBeOfType<BaseCommandResponse>();

        var cinemas = await _mockUow.Object.CinemaRepository.GetAll();

        cinemas[1].Name.ShouldNotBe("Cinema 5 U");
        cinemas[1].Location.ShouldNotBe("Location 5 U");
    }
}

