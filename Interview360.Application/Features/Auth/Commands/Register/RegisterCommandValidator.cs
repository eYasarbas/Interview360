using FluentValidation;
using Interview360.Application.Features.Auth.Dtos;
using Interview360.Application.Features.Auth.Validators.Base;

namespace Interview360.Application.Features.Auth.Commands.Register;

/// <summary>
/// Validator for the register command
/// </summary>
public class RegisterCommandValidator : AuthConfirmPasswordValidator<RegisterCommand, UserResponseDto>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email address is required");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters")
            .MaximumLength(20).WithMessage("Username must not exceed 20 characters")
            .Matches("^[a-zA-Z0-9._]*$").WithMessage("Username can only contain letters, numbers, dots and underscores");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one number");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Password confirmation is required")
            .Equal(x => x.Password).WithMessage("Passwords do not match");

        RuleFor(x => x.Bio)
            .MaximumLength(500).WithMessage("Bio must not exceed 500 characters")
            .When(x => !string.IsNullOrEmpty(x.Bio));
    }
}