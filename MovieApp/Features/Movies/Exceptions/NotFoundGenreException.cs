namespace MovieApp.Features.Movies.Exceptions;

public class NotFoundGenreException
    : Exception
{
    public NotFoundGenreException(int genreId)
        : base($"{genreId} numaralı film türü mevcut değil")
    {
    }
}