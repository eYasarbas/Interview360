using Interview360.Domain.Abstraction;
using Interview360.Domain.AppEntities.Content;
using Interview360.Domain.Enums;
using Interview360.Domain.Identity;

namespace Interview360.Domain.AppEntities.Social
{
    public class Post : Entity<Guid>
    {
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public MediaType MediaType { get; set; }
        public PostStatus Status { get; set; }
        public Guid UserId { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int ShareCount { get; set; }
        public int ViewCount { get; set; }
        public int SaveCount { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string? RejectionReason { get; set; }
        public bool IsDeleted { get; set; }

        // Media restrictions
        public long? MediaSize { get; set; } // in bytes
        public MediaFormat MediaFormat { get; set; }
        public int? MediaWidth { get; set; }
        public int? MediaHeight { get; set; }

        // Navigation properties
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser? Updater { get; set; }
        public virtual ApplicationUser? Deleter { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public virtual ICollection<PostSave> Saves { get; set; }
    }
}