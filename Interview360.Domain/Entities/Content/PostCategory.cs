using System;
using Interview360.Domain.Abstraction;
using Interview360.Domain.AppEntities.Social;

namespace Interview360.Domain.AppEntities.Content
{
    public class PostCategory : Entity<Guid>
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }

        // Navigation properties
        public virtual Post Post { get; set; }
        public virtual Category Category { get; set; }
    }
} 