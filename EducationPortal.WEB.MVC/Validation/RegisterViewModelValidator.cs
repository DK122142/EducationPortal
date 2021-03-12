using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.WEB.MVC.ViewModels;
using FluentValidation;

namespace EducationPortal.WEB.MVC.Validation
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
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

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(40)
                .WithMessage("Password length must be from 4 to 40")
                .Equal(x => x.Password)
                .WithMessage("Passwords not match");  
        }
    }
}
