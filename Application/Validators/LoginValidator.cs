using AcademyManager.Application.DTO;
using FluentValidation;

namespace AcademyManager.Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginUserDto>
    {
        public LoginValidator() 
        {
            RuleFor(LoginUserDto => LoginUserDto.UserName)
                .NotEmpty().WithMessage("UserName is Required");

            RuleFor(LoginUserDto => LoginUserDto.Password)
                .NotEmpty().WithMessage("Password is Required")
                .MinimumLength(4).WithMessage("Passwaord must be at 4 charcters long");

        }
    }
}
