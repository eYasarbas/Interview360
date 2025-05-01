namespace Interview360.Application.Features.Auth.Dtos;

public record RegisterDto
{
    public string Email { get; init; } = null!;
    public string UserName { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string ConfirmPassword { get; init; } = null!;
    public string? ProfileImage { get; init; }
    public string? Bio { get; init; }
} 