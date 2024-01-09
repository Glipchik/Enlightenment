using EnlightenmentApp.API.Models.Module;
using FluentValidation;

namespace EnlightenmentApp.API.Validators.Module
{
    public class ModuleValidator : AbstractValidator<ModuleViewModel>
    {
        public ModuleValidator()
        {
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.ImageSrc).NotEmpty();
            RuleFor(x => x.Summary).NotEmpty();
            RuleFor(x => x.Tags).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Sections).NotEmpty();
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}
