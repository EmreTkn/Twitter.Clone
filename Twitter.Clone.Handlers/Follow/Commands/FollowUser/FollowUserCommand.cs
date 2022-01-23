using MediatR;

namespace Twitter.Clone.Handlers.Follow.Commands.FollowUser;
public class FollowUserCommand : IRequest
{
    public FollowUserCommand(string followerEmail, string followedEmail)
    {
        FollowerEmail = followerEmail;
        FollowedEmail = followedEmail;
    }

    public string FollowerEmail { get; set; }
    public string FollowedEmail { get; set; }
}