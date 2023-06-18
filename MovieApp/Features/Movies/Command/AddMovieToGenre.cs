using AutoMapper;
using MediatR;
using MovieApp.Domain;
using MovieApp.ServiceManager;

namespace MovieApp.Features.Movies.Command;

public class AddMovieToGenre
{
    public class AddMovieCommand
        : IRequest<MovieResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalRevenue { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public double ImdbPoint { get; set; }
        public int GenreId { get; set; }
    }

    public class MovieResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
    }

    public class Handler : IRequestHandler<AddMovieCommand, MovieResult>
    {
        private readonly IFeatureServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IFeatureServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<MovieResult> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(request.GenreId);

            if (genre == null)
                throw new Exception(request.GenreId.ToString());

            var movie = new Movie()
            {
                Title = request.Title,
                Description = request.Description,
                GenreId = request.GenreId,
                ImdbPoint = request.ImdbPoint,
                TotalRevenue = request.TotalRevenue,
                ReleaseDate = DateTime.SpecifyKind(new DateTime(request.Year, request.Month, request.Day), DateTimeKind.Utc)
            };

            _serviceManager.Movie.AddMovieToGenre(request.GenreId, movie);
            await _serviceManager.SaveAsync();
            var result = _mapper.Map<MovieResult>(movie);
            return result;
        }
    }
}