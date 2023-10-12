using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

using Application.Common.DTOs.Cinema;
using Application.Responses;

namespace Application.Features.Cinemas.Requests.Queries;

public class GetCinemaListRequest : IRequest<List<CinemaDTO>>
{
}

