namespace Angular.ApplicationLibrary.Providers.Caching;

public interface ICacheAdapter
{
    void Add<TInput>(string key, TInput obj, DateTime? AbsoluteExpiration, TimeSpan? SlidingExpiration);
    TOutput Get<TOutput>(string key);
    void RemoveCache(string key);
}

public class FakeCacheAdapter : ICacheAdapter
{
    public void Add<TInput>(string key, TInput obj, DateTime? AbsoluteExpiration, TimeSpan? SlidingExpiration) { }

    public TOutput Get<TOutput>(string key) => default;

    public void RemoveCache(string key) { }
}
