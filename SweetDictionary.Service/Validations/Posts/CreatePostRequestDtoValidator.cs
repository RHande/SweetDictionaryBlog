using FluentValidation;
using SweetDictionary.Models.Posts;

namespace SweetDictionary.Service.Validations.Posts;

public class CreatePostRequestDtoValidator : AbstractValidator<CreatePostRequestDto>
{
    public CreatePostRequestDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100).WithMessage("Post title is not empty");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Post content is not empty");
    }
}