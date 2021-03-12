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
                .MaximumLength(200)
                .WithMessage("Name length must be from 10 to 200 symbols");

            RuleFor(x => x.Published)
                .NotEmpty();

            RuleFor(x => x.Source)
                .NotEmpty()
                .Matches(new Regex(
                    @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$",
                    RegexOptions.IgnoreCase))
                .WithMessage("Incorrect url");
        }
    }
}
