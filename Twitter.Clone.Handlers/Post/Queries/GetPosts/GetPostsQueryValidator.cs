using FluentValidation;

namespace Twitter.Clone.Handlers.Post.Queries.GetPosts;
public class GetPostsQueryValidator : AbstractValidator<GetPostsQuery>
{
    public GetPostsQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Login or register and try againe.");
    }
}