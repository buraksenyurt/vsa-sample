using AutoMapper;
using MediatR;
using MovieApp.ServiceManager;

namespace MovieApp.Features.Genres.Query;

public class GetGenre
{
    public class GetGenreQuery : IRequest<GenreResult> { public int Id { get; set; } }

    public class GenreResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Handler
        : IRequestHandler<GetGenreQuery, GenreResult>
    {
        private readonly IFeatureServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IFeatureServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<GenreResult> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(request.Id);
            var mapped = _mapper.Map<GenreResult>(genre);
            return mapped;
        }
    }
}