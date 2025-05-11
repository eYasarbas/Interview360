using Interview360.Application.Common.Models;
using Interview360.Application.Features.Categories.Dtos;

namespace Interview360.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand : BaseRequestModel<CategoryResponseDto>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
} 