using System;
using Interview360.Domain.Abstraction;
using Interview360.Domain.Identity;

namespace Interview360.Domain.AppEntities.Social
{
    public class Comment : Entity<Guid>
    {
        public string Content { get; set; }
        public string Status { get; set; } // active, deleted
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public Guid? ParentCommentId { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public Post Post { get; set; }
        public Comment ParentComment { get; set; }
    }
} 