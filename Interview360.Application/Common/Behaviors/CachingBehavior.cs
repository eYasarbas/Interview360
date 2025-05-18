using Interview360.Application.Common.Attributes;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace Interview360.Application.Common.Behaviors;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IMemoryCache _cache;
    private readonly int _slidingExpirationMinutes;

    public CachingBehavior(IMemoryCache cache)
    {
        _cache = cache;
        _slidingExpirationMinutes = 5; // Default 5 minutes
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!IsCacheable(request))
            return await next();

        var cacheKey = GetCacheKey(request);

        if (_cache.TryGetValue(cacheKey, out TResponse? cachedResponse))
            return cachedResponse!;

        var response = await next();

        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(_slidingExpirationMinutes));

        _cache.Set(cacheKey, response, cacheOptions);

        return response;
    }

    private static bool IsCacheable(TRequest request)
    {
        // Check if request type has [Cacheable] attribute
        return request.GetType().GetCustomAttribute<CacheableAttribute>() != null;
    }

    private static string GetCacheKey(TRequest request)
    {
        return $"{typeof(TRequest).Name}_{request.GetHashCode()}";
    }
}