using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Interview360.Domain.AppEntities.Social;
namespace Interview360.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? ProfileImage { get; set; }
        public string? Bio { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public DateTime? LastLoginDate { get; set; }

        // Navigation properties
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Follow> Followers { get; set; }
        public ICollection<Follow> Following { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
} 