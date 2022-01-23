using FluentValidation;
using Twitter.Clone.Data.Abstract;

namespace Twitter.Clone.Handlers.Post.Commands.CreatePost;
public class CreateNewPostCommandValidator : AbstractValidator<CreateNewPostCommand>
{
    public CreateNewPostCommandValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.UserEmailAddress).NotEmpty().WithMessage("Please login and try againe.");
        RuleFor(x => x)
            .MustAsync(async (root, command, context, cancellationToken) =>
            {
                var user = await userRepository.GetAsync(x => x.Email == command.UserEmailAddress);
                if (user == null) return false;
                return true;
            }).WithMessage("Incorrect email address.");
    }
}