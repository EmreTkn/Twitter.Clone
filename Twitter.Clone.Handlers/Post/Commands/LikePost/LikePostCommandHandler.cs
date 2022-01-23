using MediatR;
using Twitter.Clone.Data.Abstract;

namespace Twitter.Clone.Handlers.Post.Commands.LikePost
{
    public class LikePostCommandHandler : IRequestHandler<LikePostCommand>
    {
        readonly IUserRepository _userRepository;
        readonly IPostRepository _postRepository;

        public LikePostCommandHandler(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Email == request.Email);
            var post = await _postRepository.GetAsync(x => x.Id == request.PostId);
            post.AddLike(user.Id, user.Email);
            await _postRepository.UpdateAsync(post.Id, post);
            return Unit.Value;
        }
    }
}
