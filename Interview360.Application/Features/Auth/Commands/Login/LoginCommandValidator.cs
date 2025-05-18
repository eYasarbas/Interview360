using FluentValidation;
using Interview360.Application.Features.Auth.Dtos;
using Interview360.Application.Features.Auth.Validators.Base;

namespace Interview360.Application.Features.Auth.Commands.Login;

/// <summary>
/// Validator for the login command
/// </summary>
public class LoginCommandValidator : AuthPasswordValidator<LoginCommand, UserResponseDto>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.RememberMe)
            .NotNull().WithMessage("Remember me option must be specified");
    }
}