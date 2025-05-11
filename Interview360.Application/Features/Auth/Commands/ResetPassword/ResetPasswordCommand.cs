using Interview360.Application.Features.Auth.Commands.Base;
using Interview360.Application.Features.Auth.Dtos;

namespace Interview360.Application.Features.Auth.Commands.ResetPassword;

/// <summary>
/// Command for resetting user password
/// </summary>
public record ResetPasswordCommand : AuthConfirmPasswordCommand<UserResponseDto>
{
    /// <summary>
    /// New password
    /// </summary>
    public string NewPassword { get; set; }
} 