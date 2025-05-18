namespace Interview360.Infrastructure.Settings;

public class JwtSettings
{
    public string Secret { get; set; }
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public int ExpirationInDays { get; set; }
}