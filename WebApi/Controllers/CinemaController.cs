using Application.Common.DTOs.Cinema;
using Application.Features.Cinemas.Requests.Commands;
using Application.Features.Cinemas.Requests.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CinemasController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CinemasController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        this._httpContextAccessor = httpContextAccessor;
    }

    // GET: api/<CinemasController>
    [HttpGet]
    public async Task<ActionResult<List<CinemaDTO>>> GetAll()
    {
        var cinemas = await _mediator.Send(new GetCinemaListRequest());
        return Ok(cinemas);
    }


    // GET api/<CinemasController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CinemaDTO>> Get(int id)
    {
        var cinema = await _mediator.Send(new GetCinemaDetailRequest { Id = id });
        return Ok(cinema);
    }

    // POST api/<CinemasController>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<BaseCommandResponse>> Cinema([FromBody] CreateCinemaDTO cinema)
    {
        var user = _httpContextAccessor.HttpContext.User;
        var command = new CreateCinemaCommand { CinemaDto = cinema };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<CinemasController>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromBody] UpdateCinemaDTO cinema)
    {
        var command = new UpdateCinemaCommand { CinemaDto = cinema };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<CinemasController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCinemaCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
