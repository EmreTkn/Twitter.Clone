using MediatR;
using Twitter.Clone.Handlers.DTOs;
using Twitter.Clone.Handlers.Services.Interfaces;

namespace Twitter.Clone.Handlers.Account.Commands.GuestLogin;
public class GuestLoginCommandHandler : RequestHandler<GuestLoginCommand, GuestDto>
{
    readonly ITokenService _tokenService;
    public GuestLoginCommandHandler(ITokenService tokenService) => _tokenService = tokenService;
    protected override GuestDto Handle(GuestLoginCommand request)
        => new GuestDto(request.GuestName, _tokenService.CreateGuestToken(request.GuestName));
}