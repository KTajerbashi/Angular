using Extensions.ObjectMappers.Abstractions;

namespace Angular_WebApi.Utilities;

public class UtilitiesServices
{
    public readonly IMapperAdapter MapperFacade;

    public UtilitiesServices(IMapperAdapter mapperFacade)
    {
        MapperFacade = mapperFacade;
    }
}
