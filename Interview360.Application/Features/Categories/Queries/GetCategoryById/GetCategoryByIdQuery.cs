using Interview360.Application.Common.Models;
using Interview360.Application.Features.Categories.Dtos;
using Interview360.Domain.Common.Results.Base;
using MediatR;

namespace Interview360.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery : BaseRequestModel<CategoryResponseDto>
{
    public Guid Id { get; init; }
} 