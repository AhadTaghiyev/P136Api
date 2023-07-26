using System;
using ApiIntro.Dtos.Categories;
using FluentValidation;

namespace ApiIntro.Validations.Categries
{
    public class CategoryPostDtoValidation : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not empty")
                .NotNull().WithMessage("Name can not null")
                .MinimumLength(3)
                .MaximumLength(30);
            RuleFor(x => x.Description)
                 .NotEmpty().WithMessage("Name can not empty")
                .NotNull().WithMessage("Name can not null")
                .MinimumLength(3)
                .MaximumLength(100);
        }
    }
}

