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
        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment ParentComment { get; set; }
    }
} 