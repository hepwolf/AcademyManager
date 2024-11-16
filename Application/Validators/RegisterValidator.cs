using AcademyManager.Application.DTO;
using FluentValidation;
using System.Security.AccessControl;

namespace AcademyManager.Application.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterValidator()
        {
            RuleFor(RegisterUserDto => RegisterUserDto.FirstName)
            .NotEmpty().WithMessage("FirstName is Required.")
            .Length(2, 100).WithMessage("FirstName must be between 2 and 100 characters.");

            RuleFor(RegisterUserDto => RegisterUserDto.LastName)
                .NotEmpty().WithMessage("LastName is Required.")
                .Length(2, 100).WithMessage("LastName must be between 2 and 100 characters.");

            RuleFor(RegisterUserDto => RegisterUserDto.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(RegisterUserDto => RegisterUserDto.UserName)
                .NotEmpty().WithMessage("UserName is Required");

            RuleFor(RegisterUserDto => RegisterUserDto.Password)
                .NotEmpty().WithMessage("Password is Required")
                .MinimumLength(4).WithMessage("Passwaord must be at 4 charcters long");


        }
    }
}
