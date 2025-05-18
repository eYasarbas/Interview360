namespace Interview360.Application.Features.Posts.Commands.UpsertPost
{
    public class UpsertPostResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}