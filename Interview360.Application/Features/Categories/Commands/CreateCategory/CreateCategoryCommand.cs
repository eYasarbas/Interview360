using Interview360.Application.Common.Models;
using Interview360.Application.Features.Categories.Dtos;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;
using MediatR;

namespace Interview360.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand : BaseRequestModel<CategoryResponseDto>
{
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public bool IsActive { get; init; }
} 