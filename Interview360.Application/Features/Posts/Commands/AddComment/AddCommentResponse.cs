namespace Interview360.Application.Features.Posts.Commands.AddComment
{
    public class AddCommentResponse
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public Guid? ParentCommentId { get; set; }
        public int CommentCount { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}