using EnlightenmentApp.API.Models.ModuleReview;
using FluentValidation;

namespace EnlightenmentApp.API.Validators.ModuleReview
{
    public class ModuleReviewValidator : AbstractValidator<ModuleReviewViewModel>
    {
        public ModuleReviewValidator()
        {
            RuleFor(x => x.Rating).NotEmpty();
            RuleFor(x => x.ReviewText).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.ModuleId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}
