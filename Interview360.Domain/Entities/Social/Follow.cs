using System;
using Interview360.Domain.Abstraction;
using Interview360.Domain.Identity;

namespace Interview360.Domain.AppEntities.Social
{
    public class Follow : Entity<Guid>
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }

        // Navigation properties
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Following { get; set; }
    }
} 