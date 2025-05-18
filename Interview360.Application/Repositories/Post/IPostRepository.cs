using Interview360.Application.Common.Interfaces;

namespace Interview360.Application.Repositories.Post;

public interface IPostRepository : IRepository<Domain.AppEntities.Social.Post>
{
    Task<List<Interview360.Domain.AppEntities.Social.Post>> GetUserPostsAsync(Guid userId, int skip = 0, int take = 10);
    Task<List<Interview360.Domain.AppEntities.Social.Post>> GetPendingPostsAsync(int skip = 0, int take = 10);
    Task<Interview360.Domain.AppEntities.Social.Post?> GetPostWithDetailsAsync(Guid postId);
}