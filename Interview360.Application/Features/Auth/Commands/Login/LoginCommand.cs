using Interview360.Application.Features.Auth.Commands.Base;
using Interview360.Application.Features.Auth.Dtos;

namespace Interview360.Application.Features.Auth.Commands.Login;

/// <summary>
/// Command for user login
/// </summary>
public record LoginCommand : AuthPasswordCommand<UserResponseDto>
{
    /// <summary>
    /// Whether to remember the user's login
    /// </summary>
    public bool RememberMe { get; init; }
}