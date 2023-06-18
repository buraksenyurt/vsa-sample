using MediatR;
using MovieApp.Features.Movies.Exceptions;
using MovieApp.ServiceManager;

namespace MovieApp.Features.Movies.Command;

public class DeleteMovie
{
    public class DeleteMovieCommand : IRequest<Unit>
    {
        public int MovieId { get; set; }
    }

    public class Handler
        : IRequestHandler<DeleteMovieCommand, Unit>
    {
        private readonly IFeatureServiceManager _serviceManager;
        public Handler(IFeatureServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _serviceManager.Movie.GetMovieAsync(request.MovieId);
            if (movie == null)
            {
                throw new NotFoundMovieException(request.MovieId);
            }
            _serviceManager.Movie.DeleteMovie(movie);
            await _serviceManager.SaveAsync();
            return Unit.Value;
        }
    }
}