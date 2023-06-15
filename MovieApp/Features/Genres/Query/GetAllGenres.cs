using AutoMapper;
using MediatR;
using MovieApp.ServiceManager;

namespace MovieApp.Features.Genres.Query;

public class GetAllGenres
{
    public class GetAllGenresQuery : IRequest<IEnumerable<GenreResult>> { }

    public class GenreResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Handler
        : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreResult>>
    {
        private readonly IFeatureServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IFeatureServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreResult>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _serviceManager.Genre.GetAllGenresAsync();
            var mappedList = _mapper.Map<IEnumerable<GenreResult>>(genres);
            return mappedList;
        }
    }
}