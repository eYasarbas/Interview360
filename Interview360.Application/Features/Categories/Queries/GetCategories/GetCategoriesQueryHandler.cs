using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Features.Categories.Dtos;
using Interview360.Application.Features.Categories.Specifications;
using Interview360.Application.Repositories.Category;
using Interview360.Domain.Common.Results.Base;
using Microsoft.EntityFrameworkCore;

namespace Interview360.Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : BaseRequestHandler<GetCategoriesQuery, IEnumerable<CategoryResponseDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        : base(mapper)
    {
        _categoryRepository = categoryRepository;
    }

    public override async Task<IDataResult<IEnumerable<CategoryResponseDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query = _categoryRepository.Query();

        if (request.IsActive.HasValue)
        {
            var specification = new ActiveCategoriesSpecification();
            query = query.Where(specification.Criteria);
        }

        var categories = await query.ToListAsync(cancellationToken);
        var mappedCategories = _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
        
        return Success(mappedCategories, "Categories retrieved successfully");
    }
} 