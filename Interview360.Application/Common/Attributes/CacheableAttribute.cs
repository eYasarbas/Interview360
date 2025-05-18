namespace Interview360.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CacheableAttribute : Attribute
{
    public int SlidingExpirationMinutes { get; }

    public CacheableAttribute(int slidingExpirationMinutes = 5)
    {
        SlidingExpirationMinutes = slidingExpirationMinutes;
    }
}