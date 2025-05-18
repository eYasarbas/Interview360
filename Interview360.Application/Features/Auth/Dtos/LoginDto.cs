namespace Interview360.Application.Features.Auth.Dtos;

public record LoginDto
{
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
    public bool RememberMe { get; init; }
}