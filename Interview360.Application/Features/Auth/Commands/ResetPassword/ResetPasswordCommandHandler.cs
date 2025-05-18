using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Common.Interfaces;
using Interview360.Application.Features.Auth.Dtos;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;

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
            return new ErrorDataResult<UserResponseDto>("User not found");

        // Generate reset token
        var (tokenGenerated, token) = await _authService.GeneratePasswordResetTokenAsync(request.Email);
        if (!tokenGenerated || token == null)
            return new ErrorDataResult<UserResponseDto>("Failed to generate password reset token");

        // Reset password using the token
        var (isSucceed, errors) = await _authService.ResetPasswordAsync(request.Email, token, request.NewPassword);
        if (!isSucceed)
            return new ErrorDataResult<UserResponseDto>(string.Join(", ", errors));

        var response = _mapper.Map<UserResponseDto>(user);
        return new SuccessDataResult<UserResponseDto>(response, "Password has been reset successfully");
    }
}