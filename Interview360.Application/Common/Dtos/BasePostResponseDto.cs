using Interview360.Domain.Enums;

namespace Interview360.Application.Common.Dtos
{
    public class BasePostResponseDto : IDto
    {
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public MediaType MediaType { get; set; }
        public PostStatus Status { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int ShareCount { get; set; }
        public int ViewCount { get; set; }
        public int SaveCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime? InterviewDate { get; set; }
    }
} 