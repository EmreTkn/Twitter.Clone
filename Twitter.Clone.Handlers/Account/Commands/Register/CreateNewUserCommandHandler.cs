using MediatR;
using Twitter.Clone.Data.Abstract;
using Twitter.Clone.Handlers.DTOs;
using Twitter.Clone.Handlers.Services.Interfaces;
using Twitter.Clone.Models.Concrete;

namespace Twitter.Clone.Handlers.Account.Commands.Register
{
    public class CreateNewUserCommandHandler : IRequestHandler<CreateNewUserCommand, UserDto>
    {
        readonly IUserRepository _userRepository;
        readonly IIdentityRepository _identityRepository;
        readonly ITokenService _tokenService;

        public CreateNewUserCommandHandler(IUserRepository userRepository, IIdentityRepository identityRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _identityRepository = identityRepository;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = await _identityRepository
                .AddAsync(new IdentityUser
                {
                    Email = request.Email,
                    Password = request.Password
                });

            await _userRepository.AddAsync(new User
            (
                identityUser.Id,
                request.FullName,
                request.Username,
                request.Email
            ));

            var (accessToken, refreshToken) = _tokenService.CreateToken(identityUser);

            return new UserDto(
                request.Email,
                accessToken,
                refreshToken);
        }
    }
}
