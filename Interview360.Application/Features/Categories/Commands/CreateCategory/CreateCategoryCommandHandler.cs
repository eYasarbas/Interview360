using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Features.Categories.Dtos;
using Interview360.Application.Repositories.Category;
using Interview360.Domain.AppEntities.Content;
using Interview360.Domain.Common.Results.Base;

namespace Interview360.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : BaseRequestHandler<CreateCategoryCommand, CategoryResponseDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        : base(mapper)
    {
        _categoryRepository = categoryRepository;
    }

    public override async Task<IDataResult<CategoryResponseDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        var addedCategory = await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();
        
        var mappedCategory = _mapper.Map<CategoryResponseDto>(addedCategory);
        return Success(mappedCategory, "Category created successfully");
    }
} 