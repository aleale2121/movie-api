using AutoMapper;
using Application.Common.DTOs.Cinema;
using Application.Common.DTOs.Movie;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cinema, CinemaDTO>().ReverseMap();
        CreateMap<Cinema, CreateCinemaDTO>().ReverseMap();
        CreateMap<Cinema, UpdateCinemaDTO>().ReverseMap();

        CreateMap<Movie, MovieDTO>().ReverseMap();        
        CreateMap<Movie, CreateMovieDTO>().ReverseMap();
        CreateMap<Movie, UpdateMovieDTO>().ReverseMap();
    }
}

