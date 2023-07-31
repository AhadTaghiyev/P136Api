using System;
using System.Text.RegularExpressions;
using ApiIntro.Service.Dtos.Accounts;
using FluentValidation;

namespace ApiIntro.Service.Validations.Accounts
{
	public class RegisterDtoValidation:AbstractValidator<RegisterDto>
	{
		public RegisterDtoValidation()
		{
			RuleFor(x => x.Username)
				.MinimumLength(8)
				.MaximumLength(25)
				.NotEmpty().NotNull();
			RuleFor(x => x).Custom((x, context) =>
			{
				Regex regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}(\\.[a-zA-Z]{2,})?$");

				if (!regex.IsMatch(x.Email))
				{
					context.AddFailure("Email", "the email is not valid");
				}
			});
			RuleFor(x => x.Password)
				.NotEmpty()
				.NotNull()
				.MinimumLength(8);

			RuleFor(x => x).Custom((x, context) =>
			{
				if (x.Password != x.Confirmpassword)
				{
					context.AddFailure("Confirmpassword", "Password is not match");
				}
			});
		}
	}
}

