using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Repositories.Post;
using Interview360.Domain.AppEntities.Social;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;
using Microsoft.EntityFrameworkCore;

namespace Interview360.Application.Features.Posts.Commands.LikePost
{
    public class LikePostCommandHandler : BaseRequestHandler<LikePostCommand, LikePostResponse>
    {
        private readonly IPostRepository _postRepository;

        public LikePostCommandHandler(
            IPostRepository postRepository,
            IMapper mapper) : base(mapper)
        {
            _postRepository = postRepository;
        }

        public override async Task<IDataResult<LikePostResponse>> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.Query()
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(p => p.Id == request.PostId && !p.IsDeleted);

            if (post == null)
            {
                return new NotFoundDataResult<LikePostResponse>("Post not found");
            }

            var existingLike = post.Likes.FirstOrDefault(l => l.UserId == request.UserId);
            var isLiked = existingLike != null;

            if (isLiked)
            {
                // Unlike
                post.Likes.Remove(existingLike);
                post.LikeCount--;
            }
            else
            {
                // Like
                var like = new Like
                {
                    PostId = request.PostId,
                    UserId = request.UserId
                };
                post.Likes.Add(like);
                post.LikeCount++;
            }

            await _postRepository.SaveChangesAsync();

            var response = new LikePostResponse
            {
                PostId = request.PostId,
                UserId = request.UserId,
                IsLiked = !isLiked, // Toggle the like status
                LikeCount = post.LikeCount,
                IsSuccess = true,
                Message = !isLiked ? "Post liked successfully" : "Post unliked successfully"
            };

            return new SuccessDataResult<LikePostResponse>(response);
        }
    }
}