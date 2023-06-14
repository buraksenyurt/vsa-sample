using MovieApp.Features.Genres;
using MovieApp.Features.Movies;

namespace MovieApp.ServiceManager;

public interface IFeatureServiceManager
{
    IGenreService Genre {get;}
    IMovieService Movie {get;}
    Task SaveAsync();   
}