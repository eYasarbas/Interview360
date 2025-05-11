using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Interview360.Domain.AppEntities.Blog;

namespace Interview360.Persistence.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IconUrl)
                .HasMaxLength(500);

            // Index'ler
            builder.HasIndex(x => x.Title);
            builder.HasIndex(x => x.IsActive);
            builder.HasIndex(x => x.DisplayOrder);
        }
    }
} 