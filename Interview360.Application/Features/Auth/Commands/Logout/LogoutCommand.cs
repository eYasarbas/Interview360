using Interview360.Application.Common.Models;
using Interview360.Domain.Common.Results.Base;

namespace Interview360.Application.Features.Auth.Commands.Logout;

public record LogoutCommand : BaseRequestModel<IResult>
{
    public string Token { get; init; } = null!;
}