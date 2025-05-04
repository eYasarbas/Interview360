using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Interview360.Domain.AppEntities.Social;

namespace Interview360.Persistence.Configurations
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(x => x.Id);

            // Follower ile ilişki
            builder.HasOne(x => x.Follower)
                .WithMany(x => x.Following)
                .HasForeignKey(x => x.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Following ile ilişki
            builder.HasOne(x => x.Following)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Index'ler
            builder.HasIndex(x => x.FollowerId);
            builder.HasIndex(x => x.FollowingId);
        }
    }
} 