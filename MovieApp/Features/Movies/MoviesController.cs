using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Features.Movies.Command;

namespace MovieApp.Features.Movies;

[Route("api/[controller]")]
[ApiController]
public class MoviesController
    : ControllerBase
{
    private readonly IMediator _mediator;
    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> AddMovie(AddMovieToGenre.AddMovieCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Conflict(new
            {
                ex.Message
            });
        }
    }
}