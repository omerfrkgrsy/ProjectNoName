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
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
		IUserService _userService;
		public UserRegisterValidator(IUserService userService)
		{
			_userService = userService;

			RuleFor(x => x.Name)
				.NotNull()
				.WithMessage("İsim boş olamaz")
				.Length(2,20)
				.WithMessage("İsim 2-20 karakter arasında olmalıdır.");

			RuleFor(x => x.Surname)
				.NotNull()
				.WithMessage("Soyisim boş olamaz")
				.Length(2,16)
				.WithMessage("İsim 2-20 karakter arasında olmalıdır.");

			RuleFor(x => x.Email)
				.NotNull()
				.WithMessage("Email boş olamaz")
				.MaximumLength(50)
				.WithMessage("Email 50 karakter arasında olmalıdır.")
				.EmailAddress()
				.WithMessage("Email formatı doğru değil")
				.Must(isEmailExist)
				.WithMessage("Email zaten var.");

			RuleFor(x => x.Pasword)
				.NotNull()
				.WithMessage("Şifre boş olamaz.")
				.Length(8,16)
				.WithMessage("Şifre 8-16 karakter arasında olmalıdır.")
				.Equal(x=>x.RePasword)
				.WithMessage("Şifre ile şifre tekrarı uyuşmuyor.");

		}

		private bool isEmailExist(string email)
        {
			return !_userService.GetAllQueryable().Any(x => x.Email == email);
		}
	}
}
