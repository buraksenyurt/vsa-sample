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

    [HttpGet(Name ="Get Genre")]
    public async Task<ActionResult<IEnumerable<GetAllGenres.AllGenreResult>>> GetGenresAsync()
    {
        var result = await _mediator.Send(new GetAllGenres.GetAllGenresQuery());

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("{genreId}",Name ="Get Genre By Id")]
    public async Task<ActionResult<GetGenre.GenreResult>> GetGenreAsync(int genreId)
    {
        var result = await _mediator.Send(new GetGenre.GetGenreQuery() { Id = genreId });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("detail/{genreId}",Name ="Get Genre Detail")]
    public async Task<ActionResult<GetGenreDetail.GenreDetailResult>> GetGenreDetailAsync(int genreId)
    {
        var result = await _mediator.Send(new GetGenreDetail.GetGenreQuery() { Id = genreId });

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}