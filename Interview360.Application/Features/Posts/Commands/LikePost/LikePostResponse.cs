namespace Interview360.Application.Features.Posts.Commands.LikePost
{
    public class LikePostResponse
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public bool IsLiked { get; set; }
        public int LikeCount { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}