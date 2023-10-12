using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Movie.Validators;
using Application.Common.Exceptions;
using Application.Features.Movies.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Movies.Handlers.Commands;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand,BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var movie = await _unitOfWork.MovieRepository.Get(request.Id);
        response.Id = request.Id; 
        if (movie == null){
            response.Success = false;
            response.Message = "Movie Update Failed";
            response.Errors = new List<string>{
                "movie not found"
            };
        }else{
            await _unitOfWork.MovieRepository.Delete(movie);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Movie Deleted";   
        }   
        return response;
    }
}

