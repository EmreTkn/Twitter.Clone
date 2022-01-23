using MediatR;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Post.Commands.CreatePost;
public class CreateNewPostCommand : IRequest<PostCreatedDto>
{
    public CreateNewPostCommand(string userEmailAddress, string content)
    {
        UserEmailAddress = userEmailAddress;
        Content = content;
    }

    public string UserEmailAddress { get; set; }
    public string Content { get; set; }
}