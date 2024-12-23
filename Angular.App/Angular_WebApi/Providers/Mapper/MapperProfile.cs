using AutoMapper;
using Extensions.ObjectMappers.Abstractions;

namespace Angular_WebApi.Providers.Mapper;

public class AutoMapperAdapter : IMapperAdapter
{
    private readonly IMapper _mapper;
    private readonly ILogger<AutoMapperAdapter> _logger;

    public AutoMapperAdapter(IMapper mapper, ILogger<AutoMapperAdapter> logger)
    {
        _mapper = mapper;
        _logger = logger;
        _logger.LogInformation("AutoMapper Adapter Start working");
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        _logger.LogTrace("AutoMapper Adapter Map {source} To {destination} with data {sourcedata}",
                         typeof(TSource),
                         typeof(TDestination),
                         source);

        return _mapper.Map<TDestination>(source);
    }

    public List<TDestination> Map<TSource, TDestination>(List<TSource> source)
    {
        _logger.LogTrace("AutoMapper Adapter Map {source} To {destination} with data {sourcedata}",
                         typeof(TSource),
                         typeof(TDestination),
                         source);

        return _mapper.Map<List<TDestination>>(source);
    }
}
