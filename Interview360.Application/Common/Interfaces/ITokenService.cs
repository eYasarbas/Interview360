using Interview360.Domain.Identity;

namespace Interview360.Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateToken(ApplicationUser user, IList<string> roles);
    bool ValidateToken(string token);
    string GetUserIdFromToken(string token);
    Task InvalidateTokenAsync(string userId);
    Task<bool> IsTokenValidAsync(string token);
} 