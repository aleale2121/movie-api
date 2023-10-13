using Application.Common.DTOs.Movie;
using Application.Features.Movies.Requests.Commands;
using Application.Features.Movies.Requests.Queries;
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
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MoviesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        this._httpContextAccessor = httpContextAccessor;
    }

    // GET: api/<MoviesController>
    [HttpGet]
    public async Task<ActionResult<List<MovieDTO>>> GetAll()
    {
        var movies = await _mediator.Send(new GetMovieListRequest());
        return Ok(movies);
    }


    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDTO>> Get(int id)
    {
        var movie = await _mediator.Send(new GetMovieDetailRequest { Id = id });
        return Ok(movie);
    }

    // POST api/<MoviesController>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<BaseCommandResponse>> Movie([FromBody] CreateMovieDTO movie)
    {
        var user = _httpContextAccessor.HttpContext.User;
        var command = new CreateMovieCommand { MovieDto = movie };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<MoviesController>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromBody] UpdateMovieDTO movie)
    {
        var command = new UpdateMovieCommand { MovieDto = movie };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMovieCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
