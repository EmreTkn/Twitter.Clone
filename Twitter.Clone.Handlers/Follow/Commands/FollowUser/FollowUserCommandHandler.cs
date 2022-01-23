using MediatR;
using Twitter.Clone.Data.Abstract;

namespace Twitter.Clone.Handlers.Follow.Commands.FollowUser
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand>
    {
        readonly IUserRepository _userRepository;

        public FollowUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
            var followerUser = await _userRepository.GetAsync(x => x.Email == request.FollowerEmail);
            var followedUser = await _userRepository.GetAsync(x => x.Email == request.FollowedEmail);
            followerUser.AddFollowed(new Models.Concrete.Follow(followedUser.Id, followedUser.Email, followedUser.FullName));
            followedUser.AddFollower(new Models.Concrete.Follow(followerUser.Id, followerUser.Email, followerUser.FullName));
            await _userRepository.UpdateAsync(followedUser.Id, followedUser);
            await _userRepository.UpdateAsync(followerUser.Id, followerUser);
            return Unit.Value;
        }
    }
}
