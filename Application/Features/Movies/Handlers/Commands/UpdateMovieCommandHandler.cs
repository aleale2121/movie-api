using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Movie.Validators;
using Application.Common.Exceptions;
using Application.Features.Movies.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Movies.Handlers.Commands;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateMovieCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateMovieDtoValidator();
        var validationResult = await validator.ValidateAsync(request.MovieDto);

        if (validationResult.IsValid == false){

            response.Success = false;
            response.Message = "Movie Update Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        }else{

            var movie = await _unitOfWork.MovieRepository.Get(request.MovieDto.Id);
            if (movie is null){
                response.Success = false;
                response.Message = "Movie Update Failed";
                response.Errors = new List<string>{
                    "Movie not found"
                };
            }else{
                _mapper.Map(request.MovieDto, movie);
                await _unitOfWork.MovieRepository.Update(movie);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = movie.Id;
            }
        }
        return response;
    }
}

