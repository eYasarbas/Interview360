namespace Interview360.Application.Features.Categories.Commands.UpsertCategory
{
    public class UpsertCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}