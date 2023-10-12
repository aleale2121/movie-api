using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Cinema.Validators;
using Application.Common.Exceptions;
using Application.Features.Cinemas.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Cinemas.Handlers.Commands;

public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand,BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCinemaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var cinema = await _unitOfWork.CinemaRepository.Get(request.Id);
        response.Id = request.Id; 
        if (cinema == null){
            response.Success = false;
            response.Message = "Cinema Update Failed";
            response.Errors = new List<string>{
                "cinema not found"
            };
        }else{
            await _unitOfWork.CinemaRepository.Delete(cinema);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Cinema Deleted";   
        }   
        return response;
    }
}

