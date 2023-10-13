using Application.Contracts.Persistence;
using Domain.Entites;
using Domain.Common;

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks;

public static class MockCinemaRepository
{
    public static Mock<ICinemaRepository> GetCinemaRepository()
    {
        var cinemas = new List<Cinema>{
                new Cinema
                {
                    Id = 1,
                    Name = "Cinema 1",
                    Location = "Location 1",
                    Address = "Address 1",
                    Phone = "+123-4567890123"
                },
                new Cinema
                {
                    Id = 2,
                    Name = "Cinema 2",
                    Location = "Location 2",
                    Address = "Address 2",
                    Phone = "+123-4567890123"
                },
                new Cinema
                {
                    Id = 3,
                    Name = "Cinema 3",
                    Location = "Location 3",
                    Address = "Address 3",
                    Phone = "+123-4567890123"
                },
                new Cinema
                {
                    Id = 4,
                    Name = "Cinema 4",
                    Location = "Location 4",
                    Address = "Address 4",
                    Phone = "+123-4567890123"
                }
            };

        var mockRepo = new Mock<ICinemaRepository>();
        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(cinemas);

        mockRepo.Setup(r => r.Add(It.IsAny<Cinema>())).ReturnsAsync((Cinema cinema) =>
        {
            cinemas.Add(cinema);
            return cinema;
        });


        return mockRepo;

    }
}

