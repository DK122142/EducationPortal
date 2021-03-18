using EducationPortal.WEB.MVC.ViewModels;
using FluentValidation;

namespace EducationPortal.WEB.MVC.Validation
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(40)
                .WithMessage("Username length must be from 4 to 40");

            RuleFor(x=>x.Password)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(40)
                .WithMessage("Password length must be from 4 to 40");

        }
    }
}
