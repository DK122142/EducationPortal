using System;
using EducationPortal.WEB.MVC.ViewModels;
using FluentValidation;

namespace EducationPortal.WEB.MVC.Validation
{
    public class ArticleViewModelValidator : AbstractValidator<ArticleCreateViewModel>
    {
        public ArticleViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(200);

            RuleFor(x => x.Published)
                .NotEmpty();

            RuleFor(x => x.Source)
                .NotEmpty()
                .Must(x => new Uri(x).IsWellFormedOriginalString());
        }
    }
}
