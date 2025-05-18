using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Repositories.Post;
using Interview360.Domain.AppEntities.Social;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;
using Microsoft.EntityFrameworkCore;

namespace Interview360.Application.Features.Posts.Commands.SavePost
{
    public class SavePostCommandHandler : BaseRequestHandler<SavePostCommand, SavePostResponse>
    {
        private readonly IPostRepository _postRepository;

        public SavePostCommandHandler(
            IPostRepository postRepository,
            IMapper mapper) : base(mapper)
        {
            _postRepository = postRepository;
        }

        public override async Task<IDataResult<SavePostResponse>> Handle(SavePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.Query()
                .Include(p => p.Saves)
                .FirstOrDefaultAsync(p => p.Id == request.PostId && !p.IsDeleted);

            if (post == null)
            {
                return new NotFoundDataResult<SavePostResponse>("Post not found");
            }

            // Check if user is trying to save their own post
            if (post.UserId == request.SavedByUserId)
            {
                return new ErrorDataResult<SavePostResponse>("You cannot save your own post");
            }

            var existingSave = post.Saves.FirstOrDefault(s => s.UserId == request.SavedByUserId);
            var isSaved = existingSave != null;

            if (isSaved)
            {
                // Unsave
                post.Saves.Remove(existingSave);
                post.SaveCount--;
            }
            else
            {
                // Save
                var save = new PostSave
                {
                    PostId = request.PostId,
                    UserId = request.SavedByUserId,
                    Note = request.Note
                };
                post.Saves.Add(save);
                post.SaveCount++;
            }

            await _postRepository.SaveChangesAsync();

            var response = new SavePostResponse
            {
                PostId = request.PostId,
                SavedByUserId = request.SavedByUserId,
                Note = request.Note,
                IsSaved = !isSaved,
                SaveCount = post.SaveCount,
                IsSuccess = true,
                Message = !isSaved ? "Post saved successfully" : "Post unsaved successfully"
            };

            return new SuccessDataResult<SavePostResponse>(response);
        }
    }
}