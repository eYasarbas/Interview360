namespace Interview360.Application.Features.Auth.Dtos;

public record ResetPasswordDto
{
    public string Email { get; init; } = null!;
    public string Token { get; init; } = null!;
    public string NewPassword { get; init; } = null!;
    public string ConfirmPassword { get; init; } = null!;
}