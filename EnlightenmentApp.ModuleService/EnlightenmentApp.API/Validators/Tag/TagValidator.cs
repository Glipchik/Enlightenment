using EnlightenmentApp.API.Models.Tag;
using FluentValidation;

namespace EnlightenmentApp.API.Validators.Tag
{
    public class TagValidator : AbstractValidator<TagViewModel>
    {
        public TagValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}
