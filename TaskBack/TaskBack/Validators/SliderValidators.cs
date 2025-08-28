using FluentValidation;
using Microsoft.AspNetCore.Http;
using TaskBack.DTOs;

namespace TaskBack.Validators;

public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
{
    public SliderCreateDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.LinkUrl)
            .Must(url => string.IsNullOrWhiteSpace(url) || Uri.TryCreate(url, UriKind.Absolute, out var u) && (u.Scheme == Uri.UriSchemeHttp || u.Scheme == Uri.UriSchemeHttps))
            .WithMessage("The LinkUrl field is not a valid fully-qualified http or https URL.")
            .When(x => !string.IsNullOrWhiteSpace(x.LinkUrl));

        RuleFor(x => x.Image)
            .NotNull().WithMessage("Image is required.")
            .Must(f => f!.Length > 0).WithMessage("Image is empty.")
            .Must(f => new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }.Contains(Path.GetExtension(f!.FileName).ToLowerInvariant()))
            .WithMessage("Unsupported image type. Allowed: .jpg, .jpeg, .png, .gif, .webp")
            .Must(f => f!.Length <= 5 * 1024 * 1024).WithMessage("Image size must be <= 5MB");
    }
}

public class SliderUpdateDtoValidator : AbstractValidator<SliderUpdateDto>
{
    public SliderUpdateDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.LinkUrl)
            .Must(url => string.IsNullOrWhiteSpace(url) || Uri.TryCreate(url, UriKind.Absolute, out var u) && (u.Scheme == Uri.UriSchemeHttp || u.Scheme == Uri.UriSchemeHttps))
            .WithMessage("The LinkUrl field is not a valid fully-qualified http or https URL.")
            .When(x => !string.IsNullOrWhiteSpace(x.LinkUrl));

        When(x => x.Image != null, () =>
        {
            RuleFor(x => x.Image)
                .Must(f => f!.Length > 0).WithMessage("Image is empty.")
                .Must(f => new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }.Contains(Path.GetExtension(f!.FileName).ToLowerInvariant()))
                .WithMessage("Unsupported image type. Allowed: .jpg, .jpeg, .png, .gif, .webp")
                .Must(f => f!.Length <= 5 * 1024 * 1024).WithMessage("Image size must be <= 5MB");
        });
    }
}
