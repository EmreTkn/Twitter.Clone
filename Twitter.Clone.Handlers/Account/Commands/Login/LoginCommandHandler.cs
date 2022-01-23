using MediatR;
using Twitter.Clone.Data.Abstract;
using Twitter.Clone.Handlers.DTOs;
using Twitter.Clone.Handlers.Services.Interfaces;

namespace Twitter.Clone.Handlers.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserDto>
    {
        readonly IIdentityRepository _identityRepository;
        readonly ITokenService _tokenService;

        public LoginCommandHandler(IIdentityRepository identityRepository, ITokenService tokenService)
        {
            _identityRepository = identityRepository;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityRepository
                .GetAsync(x => x.Email == request.Email && x.Password == request.Password);
            var (accessToken, refreshToken) = _tokenService.CreateToken(user);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiration = DateTime.Now.AddHours(24);
            await _identityRepository.UpdateAsync(user.Id, user);
            return new UserDto(user.Email, accessToken, refreshToken);
        }
    }
}
