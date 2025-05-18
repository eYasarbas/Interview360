using Interview360.Application.Repositories.Post;
using Interview360.Domain.Enums;
using Interview360.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Interview360.Persistence.Repositories.Post;

public class PostRepository : BaseRepository<Domain.AppEntities.Social.Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Domain.AppEntities.Social.Post>> GetUserPostsAsync(Guid userId, int skip = 0, int take = 10)
    {
        return await _dbSet
            .Where(p => p.UserId == userId && !p.IsDeleted)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<List<Domain.AppEntities.Social.Post>> GetPendingPostsAsync(int skip = 0, int take = 10)
    {
        return await _dbSet
            .Where(p => p.Status == PostStatus.Pending && !p.IsDeleted)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<Domain.AppEntities.Social.Post?> GetPostWithDetailsAsync(Guid postId)
    {
        return await _dbSet
            .Include(p => p.User)
            .Include(p => p.Likes)
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.Id == postId && !p.IsDeleted);
    }
}