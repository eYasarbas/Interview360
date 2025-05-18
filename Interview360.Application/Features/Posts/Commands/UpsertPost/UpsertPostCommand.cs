using Interview360.Application.Common.Models;
using Interview360.Domain.Enums;

namespace Interview360.Application.Features.Posts.Commands.UpsertPost
{
    public record UpsertPostCommand : BaseRequestModel<UpsertPostResponse>
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public MediaType MediaType { get; set; }
        public long? MediaSize { get; set; }
        public MediaFormat MediaFormat { get; set; }
        public int? MediaWidth { get; set; }
        public int? MediaHeight { get; set; }
        public PostStatus? Status { get; set; }
        public string? ModeratorId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? InterviewDate { get; set; }
        public List<Guid> CategoryIds { get; set; } = new();
    }
}