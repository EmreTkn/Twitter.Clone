using MediatR;
using Twitter.Clone.Data.Abstract;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Post.Commands.CreatePost;
public class CreateNewPostCommandHandler : IRequestHandler<CreateNewPostCommand, PostCreatedDto>
{
    readonly IUserRepository _userRepository;
    readonly IPostRepository _postRepository;

    public CreateNewPostCommandHandler(IUserRepository userRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _postRepository = postRepository;
    }

    public async Task<PostCreatedDto> Handle(CreateNewPostCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(x => x.Email == request.UserEmailAddress);
        var post = new Models.Concrete.Post(user, request.Content);
        await _postRepository.AddAsync(post);
        return new PostCreatedDto(post.Id, request.Content, user.Username, post.CreatedAt);
    }
}