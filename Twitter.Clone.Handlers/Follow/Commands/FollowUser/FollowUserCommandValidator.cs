using FluentValidation;
using Twitter.Clone.Data.Abstract;

namespace Twitter.Clone.Handlers.Follow.Commands.FollowUser;
public class FollowUserCommandValidator : AbstractValidator<FollowUserCommand>
{
    public FollowUserCommandValidator(IUserRepository userRepository)
    {
        RuleFor(x => x)
        .MustAsync(async (root, command, context, cancellationToken) =>
        {
            var followerUser = await userRepository.GetAsync(x => x.Email == command.FollowerEmail);
            var followedUser = await userRepository.GetAsync(x => x.Email == command.FollowedEmail);
            if (followedUser == null)
            {
                context.MessageFormatter.AppendArgument("Messages", "User not found");
                return false;
            }
            if (followerUser == null)
            {
                context.MessageFormatter.AppendArgument("Messages", "User not found");
                return false;
            }
            if (followedUser.Id == followerUser.Id)
            {
                context.MessageFormatter.AppendArgument("Messages", "You can't follow yourself.");
                return false;
            }
            if (followerUser.Followeds.Any(x => x.FollowUserId == followedUser.Id))
            {
                context.MessageFormatter.AppendArgument("Messages", "Already followed user.");
                return false;
            }
            return true;
        }).WithMessage("{Messages}");
    }
}
