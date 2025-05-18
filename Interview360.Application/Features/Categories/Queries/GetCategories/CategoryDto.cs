namespace Interview360.Application.Features.Categories.Queries.GetCategories;

public record CategoryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public bool IsActive { get; init; }
    public DateTime CreateDateTime { get; init; }
}