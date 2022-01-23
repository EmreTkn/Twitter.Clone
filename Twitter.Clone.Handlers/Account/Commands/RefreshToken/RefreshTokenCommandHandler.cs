using MediatR;
using Twitter.Clone.Data.Abstract;
using Twitter.Clone.Handlers.DTOs;
using Twitter.Clone.Handlers.Services.Interfaces;

namespace Twitter.Clone.Handlers.Account.Commands.RefreshToken;
public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, UserDto>
{
    readonly IIdentityRepository _identityRepository;
    readonly ITokenService _tokenService;

    public RefreshTokenCommandHandler(IIdentityRepository identityRepository, ITokenService tokenService)
    {
        _identityRepository = identityRepository;
        _tokenService = tokenService;
    }

    public async Task<UserDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _identityRepository
               .GetAsync(x => x.RefreshToken == request.RefreshToken && x.RefreshTokenExpiration > DateTime.Now);
        var (accessToken, refreshToken) = _tokenService.CreateToken(user);
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiration = DateTime.Now.AddHours(24);
        await _identityRepository.UpdateAsync(user.Id, user);
        return new UserDto(user.Email, accessToken, refreshToken);
    }
}