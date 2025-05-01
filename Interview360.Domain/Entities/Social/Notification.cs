using System;
using Interview360.Domain.Abstraction;
using Interview360.Domain.Identity;

namespace Interview360.Domain.AppEntities.Social
{
    public class Notification : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string Type { get; set; } // like, comment, follow
        public Guid? PostId { get; set; }
        public Guid? RelatedUserId { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public Post Post { get; set; }
        public ApplicationUser RelatedUser { get; set; }
    }
} 