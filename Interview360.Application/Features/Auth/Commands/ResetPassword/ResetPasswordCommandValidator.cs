using FluentValidation;
using Interview360.Application.Features.Auth.Commands.ResetPassword;
using Interview360.Application.Features.Auth.Dtos;
using Interview360.Application.Features.Auth.Validators.Base;

namespace Interview360.Application.Features.Auth.Commands.ResetPassword;

/// <summary>
/// Validator for the reset password command
/// </summary>
public class ResetPasswordCommandValidator : AuthConfirmPasswordValidator<ResetPasswordCommand, UserResponseDto>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("New password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one number");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Password confirmation is required")
            .Equal(x => x.NewPassword).WithMessage("Passwords do not match");
    }
} 