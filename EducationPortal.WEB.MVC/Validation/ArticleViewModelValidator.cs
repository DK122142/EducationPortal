using System.Text.RegularExpressions;
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
                .Matches(new Regex(@"/\b(http|https)\:\/\/(www\.)?[a-z]+\.[a-z]{2,3}\b/g", RegexOptions.IgnoreCase));
        }
    }
}
