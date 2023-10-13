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

public static class MockMovieRepository
{
    public static Mock<IMovieRepository> GetMovieRepository()
    {
        var movies = new List<Movie>{
            new Movie
            {
                Id = 1,
                Title = "Movie 1",
                Genre = "Genre 1",
                ReleaseYear = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Movie
            {
                Id = 2,
                Title = "Movie 2",
                Genre = "Genre 2",
                ReleaseYear = new DateTime(2021, 2, 15, 0, 0, 0, DateTimeKind.Utc)
            },
            new Movie
            {
                Id = 3,
                Title = "Movie 3",
                Genre = "Genre 3",
                ReleaseYear = new DateTime(2020, 5, 10, 0, 0, 0, DateTimeKind.Utc)
            },
            new Movie
            {
                Id = 4,
                Title = "Movie 4",
                Genre = "Genre 4",
                ReleaseYear = new DateTime(2019, 8, 20, 0, 0, 0, DateTimeKind.Utc)
            }
        };

        var mockRepo = new Mock<IMovieRepository>();

        mockRepo.Setup(r => r.Add(It.IsAny<Movie>())).ReturnsAsync((Movie movie) =>
        {
            movies.Add(movie);
            return movie;
        });


        return mockRepo;

    }
}

