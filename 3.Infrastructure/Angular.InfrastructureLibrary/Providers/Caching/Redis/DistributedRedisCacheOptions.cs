namespace Angular.InfrastructureLibrary.Providers.Caching.Redis;

public class DistributedRedisCacheOptions
{
    public string Configuration { get; set; } = string.Empty;
    public string InstanceName { get; set; } = string.Empty;
}
