using Interview360.Domain.AppEntities.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview360.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.IconUrl)
                .HasMaxLength(500);

            // ParentCategory ile ilişki
            builder.HasOne(x => x.ParentCategory)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // PostCategories ile ilişki
            builder.HasMany(x => x.PostCategories)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Index'ler
            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Type);
            builder.HasIndex(x => x.IsActive);
            builder.HasIndex(x => x.DisplayOrder);
        }
    }
}