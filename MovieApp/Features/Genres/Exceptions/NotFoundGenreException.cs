namespace MovieApp.Features.Genres.Exceptions;

public class NotFoundGenreException
    : Exception
{
    public NotFoundGenreException(int genreId)
        : base($"{genreId} numaralı film türü mevcut değil")
    {
    }
}