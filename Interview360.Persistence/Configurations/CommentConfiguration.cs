using Interview360.Domain.AppEntities.Social;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview360.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
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
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Post ile ilişki
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // ParentComment ile ilişki
            builder.HasOne(x => x.ParentComment)
                .WithMany()
                .HasForeignKey(x => x.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Index'ler
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.PostId);
            builder.HasIndex(x => x.ParentCommentId);
            builder.HasIndex(x => x.Status);
        }
    }
}