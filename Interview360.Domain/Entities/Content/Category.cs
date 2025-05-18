using Interview360.Domain.Abstraction;

namespace Interview360.Domain.AppEntities.Content
{
    public enum CategoryType
    {
        Companies,      // Popüler Şirketler
        Positions,      // Pozisyonlar
        GeneralQuestions, // Genel Sorular
        Trends         // Trendler
    }

    public class Category : Entity<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public CategoryType Type { get; set; }
        public int PostCount { get; set; }
        public string? IconUrl { get; set; }  // Kategori ikonu için
        public Guid? ParentCategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } // Sıralama için

        // Navigation properties
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
    }
}