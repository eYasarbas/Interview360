using Interview360.Application.Common.Models;
using Interview360.Application.Features.Categories.Dtos;

namespace Interview360.Application.Features.Categories.Queries.GetCategories;

public record GetCategoriesQuery : BaseRequestModel<IEnumerable<CategoryResponseDto>>
{
    public bool? IsActive { get; init; }
}