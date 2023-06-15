using AutoMapper;
using MovieApp.Domain;
using MovieApp.Features.Genres.Query;

namespace MovieApp.Features.Genres;

public class MapperProfile
    : Profile
{
    public MapperProfile()
    {
        CreateMap<Genre, GetAllGenres.GenreResult>();
        CreateMap<Genre, GetGenre.GenreResult>();
    }
}