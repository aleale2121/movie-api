using Domain.Entites;

namespace Persistence.Seeds;

public static class Seeds
{
    public static List<Cinema> Cinemas = new List<Cinema>{
        new Cinema
        {
            Id = 1,
            Name = "Cinema 1",
            Location = "Location 1",
            Address = "Address 1",
            Phone = "Phone 1"
        },
        new Cinema
        {
            Id = 2,
            Name = "Cinema 2",
            Location = "Location 2",
            Address = "Address 2",
            Phone = "Phone 2"
        },
        new Cinema
        {
            Id = 3,
            Name = "Cinema 3",
            Location = "Location 3",
            Address = "Address 3",
            Phone = "Phone 3"
        },
        new Cinema
        {
            Id = 4,
            Name = "Cinema 4",
            Location = "Location 4",
            Address = "Address 4",
            Phone = "Phone 4"
        }
    };

    public static List<Movie> Movies = new List<Movie>{
        new Movie
        {
            Id = 1,
            Title = "Movie 1",
            Genre = "Genre 1",
            ReleaseYear = new DateTime(2022, 1, 1)
        },
        new Movie
        {
            Id = 2,
            Title = "Movie 2",
            Genre = "Genre 2",
            ReleaseYear = new DateTime(2021, 2, 15)
        },
        new Movie
        {
            Id = 3,
            Title = "Movie 3",
            Genre = "Genre 3",
            ReleaseYear = new DateTime(2020, 5, 10)
        },
        new Movie
        {
            Id = 4,
            Title = "Movie 4",
            Genre = "Genre 4",
            ReleaseYear = new DateTime(2019, 8, 20)
        }
    };

}