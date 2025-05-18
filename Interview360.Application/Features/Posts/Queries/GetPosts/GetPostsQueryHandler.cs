using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Repositories.Post;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;
using Interview360.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Interview360.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsQueryHandler : BaseRequestHandler<GetPostsQuery, GetPostsResponse>
    {
        private readonly IPostRepository _postRepository;

        public GetPostsQueryHandler(IPostRepository postRepository, IMapper mapper)
            : base(mapper)
        {
            _postRepository = postRepository;
        }

        public override async Task<IDataResult<GetPostsResponse>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var query = _postRepository.Query();

            if (request.UserId.HasValue)
            {
                query = query.Where(p => p.UserId == request.UserId.Value);
            }

            if (request.OnlyPending)
            {
                query = query.Where(p => p.Status == PostStatus.Pending);
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize);

            var posts = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(p => p.User)
                .OrderByDescending(p => p.CreateDateTime)
                .ToListAsync(cancellationToken);

            var response = new GetPostsResponse
            {
                Posts = _mapper.Map<List<PostDto>>(posts),
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalPages = totalPages
            };

            return new SuccessDataResult<GetPostsResponse>(response);
        }
    }
}