using Interview360.Application.Common.Dtos;

namespace Interview360.Application.Features.Posts.Commands.UpsertPost
{
    public class UpsertPostResponse : BasePostResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}