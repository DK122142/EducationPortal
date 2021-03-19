using System.Text.RegularExpressions;
using EducationPortal.WEB.MVC.ViewModels;
using FluentValidation;

namespace EducationPortal.WEB.MVC.Validation
{
    public class BookViewModelValidator : AbstractValidator<BookCreateViewModel>
    {
        public BookViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(200);
            
            RuleFor(x => x.Source)
                .NotEmpty()
                .Matches(new Regex(@"/\b(http|https)\:\/\/(www\.)?[a-z]+\.[a-z]{2,3}\b/g", RegexOptions.IgnoreCase));

            RuleFor(x => x.Authors)
                .NotEmpty();

            RuleFor(x => x.Format)
                .NotEmpty();
            
            RuleFor(x => x.PublicationYear)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.PageCount)
                .NotEmpty()
                .GreaterThan(0);

        }
    }
}
