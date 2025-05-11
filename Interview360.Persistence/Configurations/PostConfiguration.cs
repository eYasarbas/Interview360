using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Interview360.Domain.AppEntities;
using Interview360.Domain.AppEntities.Social;

namespace Interview360.Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(20);

            // User ile ilişki
            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Comments ile ilişki
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Likes ile ilişki
            builder.HasMany(x => x.Likes)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // PostCategories ile ilişki
            builder.HasMany(x => x.PostCategories)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Index'ler
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.CreateDateTime);
            builder.HasIndex(x => x.Status);
        }
    }
} 