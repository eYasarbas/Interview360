using Interview360.Domain.Identity;

namespace Interview360.Application.Common.Interfaces;

public interface IAuthService
{
    Task<(bool isSucceed, string token)> LoginAsync(string email, string password, bool rememberMe);
    Task<(bool isSucceed, string[] errors)> RegisterAsync(ApplicationUser user, string password);
    Task<bool> LogoutAsync(string userId);
    Task<bool> ValidateTokenAsync(string token);
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
    Task<ApplicationUser?> GetUserByIdAsync(string userId);
    Task<string> GenerateTokenAsync(ApplicationUser user);
    Task UpdateLastLoginDateAsync(ApplicationUser user);
    Task<(bool isSucceed, string? token)> GeneratePasswordResetTokenAsync(string email);
    Task<(bool isSucceed, string[] errors)> ResetPasswordAsync(string email, string token, string newPassword);
}