using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Repositories.Post;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;
using Interview360.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Interview360.Application.Features.Posts.Queries.GetPost
{
    public class GetPostQueryHandler : BaseRequestHandler<GetPostQuery, GetPostResponse>
    {
        private readonly IPostRepository _postRepository;

        public GetPostQueryHandler(IPostRepository postRepository, IMapper mapper)
            : base(mapper)
        {
            _postRepository = postRepository;
        }

        public override async Task<IDataResult<GetPostResponse>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.Query()
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == request.Id && !p.IsDeleted && p.Status == PostStatus.Approved);

            if (post == null)
            {
                return new NotFoundDataResult<GetPostResponse>("Post not found");
            }

            // Increment view count
            post.ViewCount++;
            await _postRepository.SaveChangesAsync();

            var response = _mapper.Map<GetPostResponse>(post);
            return new SuccessDataResult<GetPostResponse>(response);
        }
    }
}