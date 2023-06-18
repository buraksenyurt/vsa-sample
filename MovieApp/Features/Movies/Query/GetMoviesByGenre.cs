using AutoMapper;
using MediatR;
using MovieApp.Features.Movies.Exceptions;
using MovieApp.ServiceManager;

namespace MovieApp.Features.Movies.Query;

public class GetMoviesByGenre
{
    public class GetMoviesQuery
        : IRequest<IEnumerable<MovieResult>>
    {
        public int GenreId { get; set; }
    }

    public class MovieResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalRevenue { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double ImbdPoint { get; set; }
    }

    public class Handler
        : IRequestHandler<GetMoviesQuery, IEnumerable<MovieResult>>
    {
        private readonly IFeatureServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IFeatureServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MovieResult>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{request.GenreId} id sorgulanacak");
            var genre = await _serviceManager.Genre.GetGenreAsync(request.GenreId);
            if (genre == null)
            {
                throw new NotFoundMoviesByGenreException(request.GenreId);
            }
            var movies = await _serviceManager.Movie.GetAllMoviesAsync(genre.Id);
            var result = _mapper.Map<IEnumerable<MovieResult>>(movies);
            return result;
        }
    }
}