namespace Interview360.Application.Features.Posts.Commands.SavePost
{
    public class SavePostResponse
    {
        public Guid PostId { get; set; }
        public Guid SavedByUserId { get; set; }
        public string? Note { get; set; }
        public bool IsSaved { get; set; }
        public int SaveCount { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}