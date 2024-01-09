using EnlightenmentApp.API.Models.Section;
using FluentValidation;

namespace EnlightenmentApp.API.Validators.Section
{
    public class SectionValidator : AbstractValidator<SectionViewModel>
    {
        public SectionValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.ModuleId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}
