using EducationPortal.WEB.MVC.Models;
using FluentValidation;

namespace EducationPortal.WEB.MVC.Validation
{
    public class SkillModelValidator : AbstractValidator<SkillModel>
    {
        public SkillModelValidator()
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
