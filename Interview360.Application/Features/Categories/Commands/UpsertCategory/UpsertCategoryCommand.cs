using Interview360.Application.Common.Models;

namespace Interview360.Application.Features.Categories.Commands.UpsertCategory
{
    public record UpsertCategoryCommand : BaseRequestModel<UpsertCategoryResponse>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}