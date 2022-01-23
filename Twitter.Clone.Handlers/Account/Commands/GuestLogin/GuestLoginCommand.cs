using MediatR;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Account.Commands.GuestLogin;
public class GuestLoginCommand : IRequest<GuestDto>
{
    public string GuestName { get; set; }

    public GuestLoginCommand(string guestName)
    {
        GuestName = guestName;
    }
}