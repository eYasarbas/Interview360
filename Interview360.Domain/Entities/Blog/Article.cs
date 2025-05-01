using System;
using Interview360.Domain.Abstraction;

namespace Interview360.Domain.AppEntities.Blog
{    public class Article : Entity<Guid>
    {
        public string Title { get; set; }
        public string Url { get; set; }  // Dış bağlantı URL'i
        public string? IconUrl { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 