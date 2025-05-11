using Interview360.Application.Common.Interfaces;
using Interview360.Domain.Identity;
using Interview360.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace Interview360.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;
    private readonly IMemoryCacheService _memoryCacheService;

    public TokenService(IOptions<JwtSettings> jwtSettings, IMemoryCacheService memoryCacheService)
    {
        _jwtSettings = jwtSettings.Value;
        _memoryCacheService = memoryCacheService;
    }

    public string GenerateToken(ApplicationUser user, IList<string> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!)
            }),
            Expires = DateTime.UtcNow.AddDays(_jwtSettings.ExpirationInDays),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        // Add roles to token
        foreach (var role in roles)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return false;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _jwtSettings.ValidIssuer,
                ValidateAudience = true,
                ValidAudience = _jwtSettings.ValidAudience,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GetUserIdFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        return userId ?? throw new InvalidOperationException("User ID not found in token");
    }

    public async Task InvalidateTokenAsync(string userId)
    {
        var cacheKey = $"invalidated_token_{userId}";
        await _memoryCacheService.SetAsync(cacheKey, true, TimeSpan.FromDays(_jwtSettings.ExpirationInDays));
    }

    public async Task<bool> IsTokenValidAsync(string token)
    {
        if (!ValidateToken(token))
            return false;

        var userId = GetUserIdFromToken(token);
        var cacheKey = $"invalidated_token_{userId}";
        
        var isInvalidated = await _memoryCacheService.GetAsync<bool>(cacheKey);
        return !isInvalidated;
    }
} 