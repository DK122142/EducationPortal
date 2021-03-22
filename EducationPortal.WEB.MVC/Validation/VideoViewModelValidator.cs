using System;
using EducationPortal.WEB.MVC.ViewModels;
using FluentValidation;

namespace EducationPortal.WEB.MVC.Validation
{
    public class VideoViewModelValidator : AbstractValidator<VideoCreateViewModel>
    {
        public VideoViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(200);
            
            RuleFor(x => x.Source)
                .NotEmpty()
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.Source));
            
            RuleFor(x => x.Duration)
                .NotEmpty();

            RuleFor(x => x.Quality)
                .NotEmpty();
        }
    }
}
