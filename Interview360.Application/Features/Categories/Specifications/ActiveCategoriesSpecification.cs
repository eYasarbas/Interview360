using Interview360.Application.Common.Specifications;
using Interview360.Domain.AppEntities.Content;
using System.Linq.Expressions;

namespace Interview360.Application.Features.Categories.Specifications;

public class ActiveCategoriesSpecification : ISpecification<Category>
{
    public Expression<Func<Category, bool>> Criteria => x => x.IsActive;
    public List<Expression<Func<Category, object>>> Includes => new();
    public List<string> IncludeStrings => new();
    public Expression<Func<Category, object>>? OrderBy => null;
    public Expression<Func<Category, object>>? OrderByDescending => x => x.CreateDateTime;
    public int Take => 0;
    public int Skip => 0;
    public bool IsPagingEnabled => false;
} 