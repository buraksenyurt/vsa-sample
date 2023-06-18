using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Features.Movies.Command;
using MovieApp.Features.Movies.Exceptions;
using static MovieApp.Features.Movies.Query.GetMovie;
using static MovieApp.Features.Movies.Query.GetMoviesByGenre;

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

    [HttpPut]
    public async Task<ActionResult> UpdateMovie(UpdateMovie.UpdateMovieCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (NotFoundGenreException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return Conflict(new
            {
                ex.Message
            });
        }
    }

    [HttpGet("{genreId}")]
    public async Task<ActionResult<IEnumerable<MovieResult>>> GetMovies(int genreId)
    {
        try
        {
            var query = new GetMoviesQuery
            {
                GenreId = genreId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (NotFoundMoviesByGenreException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("detail/{movieId}")]
    public async Task<ActionResult<IEnumerable<MovieDetailResult>>> GetMovie(int movieId)
    {
        try
        {
            var query = new GetMovieDetailQuery
            {
                MovieId = movieId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (NotFoundMoviesByGenreException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteMovie(DeleteMovie.DeleteMovieCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return NoContent();
        }
        catch (NotFoundMovieException ex)
        {
            return NotFound(ex.Message);
        }
    }
}