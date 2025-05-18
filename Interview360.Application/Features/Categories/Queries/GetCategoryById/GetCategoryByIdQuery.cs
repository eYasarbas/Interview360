using Interview360.Application.Common.Models;
using Interview360.Application.Features.Categories.Dtos;

namespace Interview360.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery : BaseRequestModel<CategoryResponseDto>
{
    public Guid Id { get; init; }
}