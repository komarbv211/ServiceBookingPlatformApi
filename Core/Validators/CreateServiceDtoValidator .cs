using Core.Dto.DtoServices;
using FluentValidation;

namespace Core.Validators
{
    public class CreateServiceDtoValidator : AbstractValidator<CreateServiceDto>
    {
        public CreateServiceDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must start with an uppercase letter.");

            RuleFor(x => x.Description)
                .MaximumLength(1000);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.Provider)
                .NotEmpty().WithMessage("Provider name is required.")
                .MinimumLength(2);

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5).WithMessage("Rating must be between 0 and 5.");

            RuleFor(x => x.ReviewCount)
                .GreaterThanOrEqualTo(0).WithMessage("Review count cannot be negative.");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("Category is required.")
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
            //RuleFor(x => x.ImageUrl).Must(LinkMustBeAUri).WithMessage("Image URL must be valid.");
        }
        private static bool LinkMustBeAUri(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
