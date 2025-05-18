using Interview360.Application.Common.Models;

namespace Interview360.Application.Features.Auth.Commands.Base;

/// <summary>
/// Base class for all authentication commands
/// </summary>
/// <typeparam name="TResponse">The response type for the command</typeparam>
public abstract record AuthBaseCommand<TResponse> : BaseRequestModel<TResponse>
    where TResponse : class
{
    /// <summary>
    /// User's email address
    /// </summary>
    public string Email { get; init; } = null!;
}

/// <summary>
/// Base class for authentication commands that require password
/// </summary>
/// <typeparam name="TResponse">The response type for the command</typeparam>
public abstract record AuthPasswordCommand<TResponse> : AuthBaseCommand<TResponse>
    where TResponse : class
{
    /// <summary>
    /// User's password
    /// </summary>
    public string Password { get; init; } = null!;
}

/// <summary>
/// Base class for authentication commands that require password confirmation
/// </summary>
/// <typeparam name="TResponse">The response type for the command</typeparam>
public abstract record AuthConfirmPasswordCommand<TResponse> : AuthPasswordCommand<TResponse>
    where TResponse : class
{
    /// <summary>
    /// Confirmation of user's password
    /// </summary>
    public string ConfirmPassword { get; init; } = null!;
}