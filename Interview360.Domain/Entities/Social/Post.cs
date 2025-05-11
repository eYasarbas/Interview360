using System;
using System.Collections.Generic;
using Interview360.Domain.Abstraction;
using Interview360.Domain.AppEntities.Content;
using Interview360.Domain.Identity;

namespace Interview360.Domain.AppEntities.Social
{
    public class Post : Entity<Guid>
    {
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public string? MediaType { get; set; } // image, video
        public string Status { get; set; } // active, deleted
        public Guid UserId { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int ShareCount { get; set; }

        // Navigation properties
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
    }
} 