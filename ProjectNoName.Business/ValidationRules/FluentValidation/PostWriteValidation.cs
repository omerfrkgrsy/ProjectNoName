using FluentValidation;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Business.ValidationRules.FluentValidation
{
    public class PostWriteValidator : AbstractValidator<PostCreateDto>
    {
		public PostWriteValidator(IUserService userService)
		{

			RuleFor(x => x.Content)
				.NotNull()
				.WithMessage("İçerik boş olamaz");

			RuleFor(x => x.Audio)
				.NotNull()
				.WithMessage("Ses kaydı ekleyiniz.");

			

		}

	}
}
