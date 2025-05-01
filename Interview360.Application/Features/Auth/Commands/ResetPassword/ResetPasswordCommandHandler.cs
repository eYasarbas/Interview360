using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Common.Interfaces;
using Interview360.Application.Features.Auth.Dtos;
using Interview360.Domain.Common.Results.Base;

namespace Interview360.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommandHandler : BaseRequestHandler<ResetPasswordCommand, UserResponseDto>
{
    private readonly IAuthService _authService;

    public ResetPasswordCommandHandler(IAuthService authService, IMapper mapper)
        : base(mapper)
    {
        _authService = authService;
    }

    public override async Task<IDataResult<UserResponseDto>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _authService.GetUserByEmailAsync(request.Email);
        if (user == null)
            return Error("User not found");

        // Generate reset token
        var (tokenGenerated, token) = await _authService.GeneratePasswordResetTokenAsync(request.Email);
        if (!tokenGenerated || token == null)
            return Error("Failed to generate password reset token");

        // Reset password using the token
        var (isSucceed, errors) = await _authService.ResetPasswordAsync(request.Email, token, request.NewPassword);
        if (!isSucceed)
            return Error(string.Join(", ", errors));

        var response = _mapper.Map<UserResponseDto>(user);
        return Success(response, "Password has been reset successfully");
    }
} 