using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Repositories.Category;
using Interview360.Application.Repositories.Post;
using Interview360.Domain.AppEntities.Content;
using Interview360.Domain.AppEntities.Social;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;
using Interview360.Domain.Enums;

namespace Interview360.Application.Features.Posts.Commands.UpsertPost
{
    public class UpsertPostCommandHandler : BaseRequestHandler<UpsertPostCommand, UpsertPostResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpsertPostCommandHandler(
            IPostRepository postRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper) : base(mapper)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }

        public override async Task<IDataResult<UpsertPostResponse>> Handle(UpsertPostCommand request, CancellationToken cancellationToken)
        {
            Post post;
            bool isNewPost = !request.Id.HasValue;

            if (isNewPost)
            {
                post = _mapper.Map<Post>(request);
                post.Status = PostStatus.Pending;
                post.LikeCount = 0;
                post.CommentCount = 0;
                post.ShareCount = 0;
                post.ViewCount = 0;
                post.SaveCount = 0;
                post.IsDeleted = false;

                // Add categories
                if (request.CategoryIds.Any())
                {
                    post.PostCategories = request.CategoryIds.Select(categoryId => new PostCategory
                    {
                        PostId = post.Id,
                        CategoryId = categoryId
                    }).ToList();
                }

                await _postRepository.AddAsync(post);
            }
            else
            {
                post = await _postRepository.GetByIdAsync(request.Id.Value);
                if (post == null)
                {
                    return new NotFoundDataResult<UpsertPostResponse>("Post not found");
                }

                // Update status if provided
                if (request.Status.HasValue)
                {
                    post.Status = request.Status.Value;
                    post.UpdatedAt = DateTime.UtcNow;
                    if (!string.IsNullOrEmpty(request.ModeratorId))
                    {
                        post.UpdatedBy = Guid.Parse(request.ModeratorId);
                    }
                }

                // Handle soft delete
                if (request.IsDeleted.HasValue)
                {
                    post.IsDeleted = request.IsDeleted.Value;
                    post.UpdatedAt = DateTime.UtcNow;
                    if (!string.IsNullOrEmpty(request.ModeratorId))
                    {
                        post.UpdatedBy = Guid.Parse(request.ModeratorId);
                    }
                }

                // Update categories if provided
                if (request.CategoryIds.Any())
                {
                    // Remove existing categories
                    post.PostCategories?.Clear();

                    // Add new categories
                    post.PostCategories = request.CategoryIds.Select(categoryId => new PostCategory
                    {
                        PostId = post.Id,
                        CategoryId = categoryId
                    }).ToList();
                }

                // Update other properties
                _mapper.Map(request, post);
                await _postRepository.UpdateAsync(post);
            }

            await _postRepository.SaveChangesAsync();

            var response = _mapper.Map<UpsertPostResponse>(post);
            response.IsSuccess = true;
            response.Message = isNewPost
                ? "Post created successfully and waiting for approval"
                : post.IsDeleted
                    ? "Post deleted successfully"
                    : "Post updated successfully";

            return new SuccessDataResult<UpsertPostResponse>(response);
        }
    }
}