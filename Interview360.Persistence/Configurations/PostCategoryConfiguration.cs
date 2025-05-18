using Interview360.Domain.AppEntities.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview360.Persistence.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.HasKey(x => x.Id);

            // Post ile ilişki
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostCategories)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Category ile ilişki
            builder.HasOne(x => x.Category)
                .WithMany(x => x.PostCategories)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Composite index
            builder.HasIndex(x => new { x.PostId, x.CategoryId }).IsUnique();
        }
    }
}