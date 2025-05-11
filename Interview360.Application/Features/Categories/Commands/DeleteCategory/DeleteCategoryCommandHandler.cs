using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Features.Categories.Dtos;
using Interview360.Application.Repositories.Category;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;

namespace Interview360.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : BaseRequestHandler<DeleteCategoryCommand, CategoryResponseDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        : base(mapper)
    {
        _categoryRepository = categoryRepository;
    }

    public override async Task<IDataResult<CategoryResponseDto>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
            return new ErrorDataResult<CategoryResponseDto>("The category was not found");

        await _categoryRepository.DeleteAsync(category);
        await _categoryRepository.SaveChangesAsync();

        var mappedCategory = _mapper.Map<CategoryResponseDto>(category);
        return new SuccessDataResult<CategoryResponseDto>(mappedCategory, "The category was deleted successfully");
    }
} 