namespace Interview360.Application.Features.Auth.Dtos.Base;

public abstract record AuthBaseDto
{
    public string Email { get; init; } = null!;
}

public abstract record AuthPasswordDto : AuthBaseDto
{
    public string Password { get; init; } = null!;
}

public abstract record AuthConfirmPasswordDto : AuthPasswordDto
{
    public string ConfirmPassword { get; init; } = null!;
} 