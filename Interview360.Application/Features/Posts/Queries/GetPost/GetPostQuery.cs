using Interview360.Application.Common.Models;

namespace Interview360.Application.Features.Posts.Queries.GetPost
{
    public record GetPostQuery : BaseRequestModel<GetPostResponse>
    {
        public Guid Id { get; set; }
    }
}