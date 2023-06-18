using AutoMapper;
using MediatR;
using MovieApp.Features.Genres.Exceptions;
using MovieApp.ServiceManager;

namespace MovieApp.Features.Genres.Query;

public class GetGenreDetail
{
    public class GetGenreQuery : IRequest<GenreDetailResult> { public int Id { get; set; } }

    public class GenreDetailResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalMovies { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageRevenue { get; set; }
    }

    public class Handler
        : IRequestHandler<GetGenreQuery, GenreDetailResult>
    {
        private readonly IFeatureServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IFeatureServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<GenreDetailResult> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(request.Id);
            if (genre == null)
            {
                throw new NotFoundGenreException(request.Id);
            }
            var movies = await _serviceManager.Movie.GetAllMoviesAsync(genre.Id);
            var mapped = _mapper.Map<GenreDetailResult>(genre);

            mapped.TotalMovies = movies.Count();
            mapped.TotalRevenue = movies.Sum(m => m.TotalRevenue);
            mapped.AverageRevenue = movies.Average(m => m.TotalRevenue);

            return mapped;
        }
    }
}