using FluentValidation;
using Twitter.Clone.Data.Abstract;

namespace Twitter.Clone.Handlers.Post.Commands.LikePost;
public class LikePostCommandValidator : AbstractValidator<LikePostCommand>
{
    public LikePostCommandValidator(IUserRepository userRepository, IPostRepository postRepository)
    {
        RuleFor(x => x)
        .MustAsync(async (root, command, context, cancellationToken) =>
        {
            var user = await userRepository.GetAsync(x => x.Email == command.Email);
            if (user != null)
            {
                var post = await postRepository.GetByIdAsync(command.PostId);
                if (post != null)
                {
                    var alreadyLiked = post.Likes.Any(x => x.LikedByUserId == user.Id);
                    if (!alreadyLiked) return true;
                    context.MessageFormatter.AppendArgument("Messages", "You already liked this post");
                    return false;
                }
                context.MessageFormatter.AppendArgument("Messages", "Post is not found.");
                return false;
            }
            context.MessageFormatter.AppendArgument("Messages", "Please login and try againe.");
            return false;
        }).WithMessage("{Messages}");
    }
}