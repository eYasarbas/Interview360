using Interview360.Domain.AppEntities.Social;
using Microsoft.AspNetCore.Identity;
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
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Follow> Followers { get; set; }
        public virtual ICollection<Follow> Following { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}