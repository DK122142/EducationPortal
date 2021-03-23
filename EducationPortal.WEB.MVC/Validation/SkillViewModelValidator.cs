using EducationPortal.WEB.MVC.ViewModels;
using FluentValidation;

namespace EducationPortal.WEB.MVC.Validation
{
    public class SkillViewModelValidator : AbstractValidator<SkillCreateViewModel>
    {
        public SkillViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100);
            
            RuleFor(x => x.Description)
                .MinimumLength(1)
                .MaximumLength(1000);
        }
        
    }
}
