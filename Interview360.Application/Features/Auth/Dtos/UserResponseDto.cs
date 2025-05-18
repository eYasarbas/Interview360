using Interview360.Application.Common.Dtos;

namespace Interview360.Application.Features.Auth.Dtos;

public record UserResponseDto : IDto<Guid>
{
    public Guid Id { get; init; }
    public string Email { get; init; } = null!;
    public string UserName { get; init; } = null!;
    public string? ProfileImage { get; init; }
    public string? Bio { get; init; }
    public int FollowerCount { get; init; }
    public int FollowingCount { get; init; }
    public DateTime? LastLoginDate { get; init; }
    public string? Token { get; init; }
}