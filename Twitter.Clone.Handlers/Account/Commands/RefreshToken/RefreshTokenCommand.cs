using MediatR;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Account.Commands.RefreshToken;
public class RefreshTokenCommand : IRequest<UserDto>
{
    public string RefreshToken { get; set; }

    public RefreshTokenCommand(string refreshToken)
    {
        RefreshToken = refreshToken;
    }
}