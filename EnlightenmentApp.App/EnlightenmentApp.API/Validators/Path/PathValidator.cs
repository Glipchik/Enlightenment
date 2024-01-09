using EnlightenmentApp.API.Models.Path;
using FluentValidation;

namespace EnlightenmentApp.API.Validators.Path
{
    public class PathValidator : AbstractValidator<PathViewModel>
    {
        public PathValidator()
        {
            RuleFor(x => x.Modules).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.Summary).NotEmpty();
            RuleFor(x => x.Tags).NotEmpty();
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}
