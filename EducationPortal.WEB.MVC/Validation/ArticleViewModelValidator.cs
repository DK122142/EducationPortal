using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EducationPortal.WEB.MVC.ViewModels;
using FluentValidation;

namespace EducationPortal.WEB.MVC.Validation
{
    public class ArticleViewModelValidator : AbstractValidator<ArticleViewModel>
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
