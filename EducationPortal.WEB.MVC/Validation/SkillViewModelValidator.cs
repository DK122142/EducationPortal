using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.WEB.MVC.ViewModels;
using FluentValidation;

namespace EducationPortal.WEB.MVC.Validation
{
    public class SkillViewModelValidator : AbstractValidator<SkillViewModel>
    {
        public SkillViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100)
                .WithMessage("Name length must be from 1 to 100.");
        }
        
    }
}
