using System;
using ApiIntro.Service.Dtos.Categories;
using FluentValidation;

namespace ApiIntro.Service.Validations.Categries
{
	public class CategoryUpdateDtoValidation:AbstractValidator<CategoryUpdateDto>
	{
		public CategoryUpdateDtoValidation()
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

