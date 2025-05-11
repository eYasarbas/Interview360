using FluentValidation;
using Interview360.Application.Features.Auth.Commands.Base;
using Interview360.Application.Features.Auth.Dtos;

namespace Interview360.Application.Features.Auth.Validators.Base;

/// <summary>
/// Base validator for authentication commands
/// </summary>
/// <typeparam name="TCommand">The command type to validate</typeparam>
/// <typeparam name="TResponse">The response type associated with the command</typeparam>
public abstract class AuthBaseValidator<TCommand, TResponse> : AbstractValidator<TCommand>
    where TCommand : AuthBaseCommand<TResponse>
    where TResponse : class
{
    protected AuthBaseValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email address is required");
    }
}

/// <summary>
/// Base validator for authentication commands that require password
/// </summary>
/// <typeparam name="TCommand">The command type to validate</typeparam>
/// <typeparam name="TResponse">The response type associated with the command</typeparam>
public abstract class AuthPasswordValidator<TCommand, TResponse> : AuthBaseValidator<TCommand, TResponse>
    where TCommand : AuthPasswordCommand<TResponse>
    where TResponse : class
{
    protected AuthPasswordValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one number");
    }
}

/// <summary>
/// Base validator for authentication commands that require password confirmation
/// </summary>
/// <typeparam name="TCommand">The command type to validate</typeparam>
/// <typeparam name="TResponse">The response type associated with the command</typeparam>
public abstract class AuthConfirmPasswordValidator<TCommand, TResponse> : AuthPasswordValidator<TCommand, TResponse>
    where TCommand : AuthConfirmPasswordCommand<TResponse>
    where TResponse : class
{
    protected AuthConfirmPasswordValidator()
    {
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Password confirmation is required")
            .Equal(x => x.Password).WithMessage("Passwords do not match");
    }
} 