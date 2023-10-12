using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.DTOs.Cinema.Validators;
using Application.Common.Exceptions;
using Application.Features.Cinemas.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain.Entites;

namespace Application.Features.Cinemas.Handlers.Commands;

public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCinemaCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateCinemaDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CinemaDto);

        if (validationResult.IsValid == false){

            response.Success = false;
            response.Message = "Cinema Update Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        }else{

            var cinema = await _unitOfWork.CinemaRepository.Get(request.CinemaDto.Id);
            if (cinema is null){
                response.Success = false;
                response.Message = "Cinema Update Failed";
                response.Errors = new List<string>{
                    "Cinema not found"
                };
            }else{
                _mapper.Map(request.CinemaDto, cinema);
                await _unitOfWork.CinemaRepository.Update(cinema);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = cinema.Id;
            }
        }
        return response;
    }
}

