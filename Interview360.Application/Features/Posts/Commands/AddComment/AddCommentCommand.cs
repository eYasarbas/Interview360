using Interview360.Application.Common.Models;

namespace Interview360.Application.Features.Posts.Commands.AddComment
{
    public record AddCommentCommand : BaseRequestModel<AddCommentResponse>
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public Guid? ParentCommentId { get; set; } // For nested comments
    }
}