using Interview360.Application.Common.Models;

namespace Interview360.Application.Features.Posts.Commands.LikePost
{
    public record LikePostCommand : BaseRequestModel<LikePostResponse>
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}