using AutoMapper;
using MovieApp.Domain;
using MovieApp.Features.Movies.Command;
using MovieApp.Features.Movies.Query;

namespace MovieApp.Features.Movies;

public class MapperProfile
    : Profile
{
    public MapperProfile()
    {
        CreateMap<Movie, AddMovieToGenre.MovieResult>();
        CreateMap<Movie, GetMoviesByGenre.MovieResult>();
        CreateMap<Movie, GetMovie.MovieDetailResult>();
    }
}