using System;
using System.Text.RegularExpressions;
using ApiIntro.Service.Dtos.Accounts;
using FluentValidation;

namespace ApiIntro.Service.Validations.Accounts
{
	public class LoginDtoValidation:AbstractValidator<LoginDto>
	{
		public LoginDtoValidation()
		{
			RuleFor(x => x.Username)
				.MinimumLength(8)
				.MaximumLength(25)
				.NotEmpty().NotNull();
		
			RuleFor(x => x.Password)
				.NotEmpty()
				.NotNull()
				.MinimumLength(8);
		}
	}
}

