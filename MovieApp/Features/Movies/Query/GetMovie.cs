using AutoMapper;
using MediatR;
using MovieApp.Features.Movies.Exceptions;
using MovieApp.ServiceManager;

namespace MovieApp.Features.Movies.Query;

public class GetMovie
{
    public class GetMovieDetailQuery
        : IRequest<MovieDetailResult>
    {
        public int MovieId { get; set; }
    }

    public class MovieDetailResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalRevenue { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double ImdbPoint { get; set; }
    }

    public class Handler
        : IRequestHandler<GetMovieDetailQuery, MovieDetailResult>
    {
        private readonly IFeatureServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IFeatureServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        public async Task<MovieDetailResult> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {
            var movie = await _serviceManager.Movie.GetMovieAsync(request.MovieId);
            if (movie == null)
            {
                throw new NotFoundMovieException(request.MovieId);
            }
            var result = _mapper.Map<MovieDetailResult>(movie);
            return result;
        }
    }
}