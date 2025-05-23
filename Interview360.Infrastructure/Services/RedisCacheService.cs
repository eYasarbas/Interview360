using Interview360.Application.Common.Interfaces;
using StackExchange.Redis;

namespace Interview360.Infrastructure.Services;

public class RedisCacheService : IMemoryCacheService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _db;

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _db = redis.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _db.StringGetAsync(key);
        if (!value.HasValue)
            return default;

        return System.Text.Json.JsonSerializer.Deserialize<T>(value!);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        var serializedValue = System.Text.Json.JsonSerializer.Serialize(value);
        await _db.StringSetAsync(key, serializedValue, expiration);
    }

    public async Task RemoveAsync(string key)
    {
        await _db.KeyDeleteAsync(key);
    }
}