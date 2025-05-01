using System;
using Interview360.Domain.Abstraction;
using Interview360.Domain.Identity;
namespace Interview360.Domain.AppEntities.Social
{
    public class Like : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public Post Post { get; set; }
    }
} 