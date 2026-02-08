namespace AngularApp.Core.Application.Common.Mapper;

public static class Extensions
{
    public static TResult Map<TModel, TResult>(this IMapper mapper, TModel model)
    {
        return mapper.Map<TResult>(model);
    }
    public static List<TResult> MapList<TModel, TResult>(this IMapper mapper, List<TModel> model)
    {
        return mapper.Map<List<TResult>>(model);
    }
    public static IEnumerable<TResult> MapList<TModel, TResult>(this IMapper mapper, IEnumerable<TModel> model)
    {
        return mapper.Map<IEnumerable<TResult>>(model);
    }
}