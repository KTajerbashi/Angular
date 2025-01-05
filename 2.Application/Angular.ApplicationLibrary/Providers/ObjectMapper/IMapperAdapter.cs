namespace Angular.ApplicationLibrary.Providers.ObjectMapper;

public interface IMapperAdapter
{
    TDestination Map<TSource, TDestination>(TSource source);
    IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source);
    List<TDestination> Map<TSource, TDestination>(List<TSource> source);
}