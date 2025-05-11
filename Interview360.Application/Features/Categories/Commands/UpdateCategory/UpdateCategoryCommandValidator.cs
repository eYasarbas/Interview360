using FluentValidation;

namespace Interview360.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Kategori ID'si boş olamaz");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MaximumLength(100).WithMessage("Kategori adı 100 karakterden uzun olamaz");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama 500 karakterden uzun olamaz");
    }
} 