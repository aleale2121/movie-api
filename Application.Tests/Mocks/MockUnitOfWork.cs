using Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks;

public static class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetUnitOfWork()
    {
        var mockUow = new Mock<IUnitOfWork>();
        var mockCinemaRepo = MockCinemaRepository.GetCinemaRepository();

        mockUow.Setup(r => r.CinemaRepository).Returns(mockCinemaRepo.Object);

        return mockUow;
    }
}

