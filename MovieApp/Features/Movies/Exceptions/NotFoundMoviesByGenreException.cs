namespace MovieApp.Features.Movies.Exceptions;

public class NotFoundMoviesByGenreException
    : Exception
{
    public NotFoundMoviesByGenreException(int genreId)
        : base($"{genreId} numaralı türe ait oyunlar mevcut değil")
    {
    }
}