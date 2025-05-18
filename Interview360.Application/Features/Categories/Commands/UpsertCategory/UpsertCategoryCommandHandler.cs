using AutoMapper;
using Interview360.Application.Common.Handlers;
using Interview360.Application.Repositories.Category;
using Interview360.Domain.AppEntities.Content;
using Interview360.Domain.Common.Results.Base;
using Interview360.Domain.Common.Results.DataResults;

namespace Interview360.Application.Features.Categories.Commands.UpsertCategory
{
    public class UpsertCategoryCommandHandler : BaseRequestHandler<UpsertCategoryCommand, UpsertCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpsertCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper) : base(mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<IDataResult<UpsertCategoryResponse>> Handle(UpsertCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category;
            bool isNewCategory = !request.Id.HasValue;

            if (isNewCategory)
            {
                category = _mapper.Map<Category>(request);
                category.IsDeleted = false;

                await _categoryRepository.AddAsync(category);
            }
            else
            {
                category = await _categoryRepository.GetByIdAsync(request.Id.Value);
                if (category == null)
                {
                    return new NotFoundDataResult<UpsertCategoryResponse>("Category not found");
                }

                // Handle soft delete
                if (request.IsDeleted.HasValue)
                {
                    category.IsDeleted = request.IsDeleted.Value;
                }

                // Update other properties
                _mapper.Map(request, category);
                await _categoryRepository.UpdateAsync(category);
            }

            await _categoryRepository.SaveChangesAsync();

            var response = _mapper.Map<UpsertCategoryResponse>(category);
            response.IsSuccess = true;
            response.Message = isNewCategory
                ? "Category created successfully"
                : category.IsDeleted
                    ? "Category deleted successfully"
                    : "Category updated successfully";

            return new SuccessDataResult<UpsertCategoryResponse>(response);
        }
    }
}