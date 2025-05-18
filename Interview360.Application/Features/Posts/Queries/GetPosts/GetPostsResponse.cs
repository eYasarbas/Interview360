using Interview360.Application.Features.Posts.Queries.GetPost;

namespace Interview360.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsResponse
    {
        public List<GetPostResponse> Posts { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}