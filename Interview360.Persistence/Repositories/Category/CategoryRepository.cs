using Interview360.Application.Repositories.Category;
using Interview360.Domain.AppEntities.Content;
using Interview360.Persistence.Context;

namespace Interview360.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    // Add category-specific repository methods here if needed
} 