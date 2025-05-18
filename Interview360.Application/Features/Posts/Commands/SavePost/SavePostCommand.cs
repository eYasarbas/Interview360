using Interview360.Application.Common.Models;

namespace Interview360.Application.Features.Posts.Commands.SavePost
{
    public record SavePostCommand : BaseRequestModel<SavePostResponse>
    {
        public Guid PostId { get; set; }
        public Guid SavedByUserId { get; set; } // User who is saving the post
        public string? Note { get; set; } // Optional note for the saved post
    }
}