using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Features.Genres.Query;

namespace MovieApp.Features.Genres;

[Route("api/[controller]")]
[ApiController]
public class GenresController
    : ControllerBase
{
    private readonly IMediator _mediator;
    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAllGenres.GenreResult>>> GetGenresAsync()
    {
        var result = await _mediator.Send(new GetAllGenres.GetAllGenresQuery());

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("{genreId}")]
    public async Task<ActionResult<GetGenre.GenreResult>> GetGenreAsync(int genreId)
    {
        var result = await _mediator.Send(new GetGenre.GetGenreQuery() { Id = genreId });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("detail/{genreId}")]
    public async Task<ActionResult<GetGenreDetail.GenreResult>> GetGenreDetailAsync(int genreId)
    {
        var result = await _mediator.Send(new GetGenreDetail.GetGenreQuery() { Id = genreId });

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}