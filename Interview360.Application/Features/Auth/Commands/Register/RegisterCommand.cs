using Interview360.Application.Features.Auth.Commands.Base;
using Interview360.Application.Features.Auth.Dtos;

namespace Interview360.Application.Features.Auth.Commands.Register;

/// <summary>
/// Command for user registration
/// </summary>
public record RegisterCommand : AuthConfirmPasswordCommand<UserResponseDto>
{
    /// <summary>
    /// User's username
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// User's profile image URL
    /// </summary>
    public string? ProfileImage { get; set; }

    /// <summary>
    /// User's bio
    /// </summary>
    public string? Bio { get; set; }
} 