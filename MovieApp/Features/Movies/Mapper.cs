using AutoMapper;
using MovieApp.Domain;
using MovieApp.Features.Movies.Command;

namespace MovieApp.Features.Movies;

public class MapperProfile
    : Profile
{
    public MapperProfile()
    {
        CreateMap<Movie, AddMovieToGenre.MovieResult>();
    }
}