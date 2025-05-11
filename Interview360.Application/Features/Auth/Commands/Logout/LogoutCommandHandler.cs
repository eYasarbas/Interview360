using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Common.Interfaces;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;
using MediatR;

namespace Interview360.Application.Features.Auth.Commands.Logout;

public class LogoutCommandHandler : BaseRequestHandler<LogoutCommand, IResult>
{
    private readonly ITokenService _tokenService;

    public LogoutCommandHandler(IMapper mapper, ITokenService tokenService) : base(mapper)
    {
        _tokenService = tokenService;
    }

    public override async Task<IDataResult<IResult>> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        if (!await _tokenService.IsTokenValidAsync(request.Token))
        {
            return new ErrorDataResult<IResult>("Invalid token.");
        }

        var userId = _tokenService.GetUserIdFromToken(request.Token);

        await _tokenService.InvalidateTokenAsync(userId);

        return new SuccessDataResult<IResult>("The logout was successful");
    }
} 