using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Common.Interfaces;
using Interview360.Application.Features.Auth.Dtos;
using Interview360.Domain.Common.Results.Base;

namespace Interview360.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : BaseRequestHandler<LoginCommand, UserResponseDto>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService, IMapper mapper)
        : base(mapper)
    {
        _authService = authService;
    }

    public override async Task<IDataResult<UserResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _authService.GetUserByEmailAsync(request.Email);
        if (user == null)
            return Error("User not found");

        var (isSucceed, token) = await _authService.LoginAsync(request.Email, request.Password, request.RememberMe);
        if (!isSucceed)
            return Error("Invalid credentials");

        await _authService.UpdateLastLoginDateAsync(user);

        var response = _mapper.Map<UserResponseDto>(user);
        response = response with { Token = token };

        return Success(response, "Login successful");
    }
} 