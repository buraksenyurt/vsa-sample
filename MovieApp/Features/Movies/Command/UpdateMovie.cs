using AutoMapper;
using MediatR;
using MovieApp.Features.Movies.Exceptions;
using MovieApp.ServiceManager;

namespace MovieApp.Features.Movies.Command;

public class UpdateMovie
{
    public class UpdateMovieCommand
        : IRequest<Unit>
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalRevenue { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public double ImdbPoint { get; set; }
        public int GenreId { get; set; }
    }

    public class UpdateMovieResult
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalRevenue { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double ImdbPoint { get; set; }
        public int GenreId { get; set; }
    }

    public class Handler
        : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly IFeatureServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IFeatureServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(request.GenreId);

            if (genre == null)
                throw new NotFoundGenreException(request.GenreId);

            var movie = await _serviceManager.Movie.GetMovieAsync(request.MovieId);

            if (movie == null)
                throw new NotFoundMovieException(request.MovieId);

            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.ImdbPoint = request.ImdbPoint;
            movie.ReleaseDate = DateTime.SpecifyKind(new DateTime(request.Year, request.Month, request.Day), DateTimeKind.Utc);
            movie.TotalRevenue = request.TotalRevenue;

            await _serviceManager.SaveAsync();

            return Unit.Value;
        }
    }
}