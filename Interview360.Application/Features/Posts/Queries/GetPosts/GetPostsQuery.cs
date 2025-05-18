using Interview360.Application.Common.Models;

namespace Interview360.Application.Features.Posts.Queries.GetPosts
{
    public record GetPostsQuery : BaseRequestModel<GetPostsResponse>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Guid? UserId { get; set; }
        public bool OnlyPending { get; set; }
    }
}