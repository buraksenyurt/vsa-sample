using AutoMapper;
using MediatR;
using MovieApp.ServiceManager;

namespace MovieApp.Features.Genres.Query;

public class GetAllGenres
{
    public class GetAllGenresQuery : IRequest<IEnumerable<AllGenreResult>> { }

    public class AllGenreResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Handler
        : IRequestHandler<GetAllGenresQuery, IEnumerable<AllGenreResult>>
    {
        private readonly IFeatureServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IFeatureServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AllGenreResult>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _serviceManager.Genre.GetAllGenresAsync();
            var mappedList = _mapper.Map<IEnumerable<AllGenreResult>>(genres);
            return mappedList;
        }
    }
}