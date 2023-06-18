using AutoMapper;
using MovieApp.Domain;
using MovieApp.Features.Genres.Query;

namespace MovieApp.Features.Genres;

public class MapperProfile
    : Profile
{
    public MapperProfile()
    {
        CreateMap<Genre, GetAllGenres.AllGenreResult>();
        CreateMap<Genre, GetGenre.GenreResult>();
        CreateMap<Genre, GetGenreDetail.GenreDetailResult>();
    }
}