using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Common.Interfaces;
using Interview360.Application.Features.Auth.Dtos;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;
using Interview360.Domain.Identity;

namespace Interview360.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : BaseRequestHandler<RegisterCommand, UserResponseDto>
{
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService, IMapper mapper)
        : base(mapper)
    {
        _authService = authService;
    }

    public override async Task<IDataResult<UserResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _authService.GetUserByEmailAsync(request.Email);
        if (existingUser != null)
            return new ErrorDataResult<UserResponseDto>("Email is already registered");

        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.UserName,
            ProfileImage = request.ProfileImage,
            Bio = request.Bio,
            EmailConfirmed = true // You might want to implement email confirmation
        };

        var (isSucceed, errors) = await _authService.RegisterAsync(user, request.Password);
        if (!isSucceed)
            return new ErrorDataResult<UserResponseDto>(string.Join(", ", errors));

        var token = await _authService.GenerateTokenAsync(user);
        var response = _mapper.Map<UserResponseDto>(user);
        response = response with { Token = token };

        return new SuccessDataResult<UserResponseDto>(response, "Registration successful");
    }
}