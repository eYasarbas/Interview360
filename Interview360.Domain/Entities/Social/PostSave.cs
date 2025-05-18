using Interview360.Domain.Abstraction;
using Interview360.Domain.Identity;

namespace Interview360.Domain.AppEntities.Social
{
    public class PostSave : Entity<Guid>
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime SavedAt { get; set; }
        public string? Note { get; set; }

        // Navigation properties
        public virtual Post Post { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}