using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Repositories.Post;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;

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
            var post = await _postRepository.GetPostWithDetailsAsync(request.Id);
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