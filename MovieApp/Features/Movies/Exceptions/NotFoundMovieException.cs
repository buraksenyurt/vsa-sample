namespace MovieApp.Features.Movies.Exceptions;

public class NotFoundMovieException
    : Exception
{
    public NotFoundMovieException(int movieId)
        : base($"{movieId} numaralı oyun mevcut değil")
    {
    }
}