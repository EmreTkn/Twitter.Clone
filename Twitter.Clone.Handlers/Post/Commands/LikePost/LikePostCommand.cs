using MediatR;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Post.Commands.LikePost;
public class LikePostCommand : IRequest
{
    public LikePostCommand(string email, string postId)
    {
        Email = email;
        PostId = postId;
    }

    public string Email { get; set; }
    public string PostId { get; set; }
}