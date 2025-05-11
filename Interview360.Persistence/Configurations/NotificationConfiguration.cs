using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Interview360.Domain.AppEntities.Social;

namespace Interview360.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(20);

            // User ile ilişki
            builder.HasOne(x => x.User)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Post ile ilişki
            builder.HasOne(x => x.Post)
                .WithMany()
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            // RelatedUser ile ilişki
            builder.HasOne(x => x.RelatedUser)
                .WithMany()
                .HasForeignKey(x => x.RelatedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Index'ler
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.PostId);
            builder.HasIndex(x => x.RelatedUserId);
            builder.HasIndex(x => x.IsRead);
            builder.HasIndex(x => x.CreatedDate);
        }
    }
} 