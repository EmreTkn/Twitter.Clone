using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Twitter.Clone.Handlers.Account.Commands.GuestLogin;
using Twitter.Clone.Handlers.Account.Commands.Login;
using Twitter.Clone.Handlers.Account.Commands.RefreshToken;
using Twitter.Clone.Handlers.Account.Commands.Register;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.WebApi.Controllers;
public class AccountController : BaseApiController
{
    readonly IMediator _mediator;
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(CreateUserDto createUserDto, CancellationToken cancellationToken)
        => await _mediator.Send(new CreateNewUserCommand(createUserDto), cancellationToken);

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto, CancellationToken cancellationToken)
        => await _mediator.Send(new LoginCommand(loginDto), cancellationToken);

    [HttpPost]
    [Route("refresh-token")]
    public async Task<ActionResult<UserDto>> RefreshToken([FromBody] string refreshToken, CancellationToken cancellationToken)
        => await _mediator.Send(new RefreshTokenCommand(refreshToken), cancellationToken);

    [HttpPost]
    [Route("guest")]
    public async Task<ActionResult<GuestDto>> CreateAndLoginAsGuest([FromBody] string guestName, CancellationToken cancellationToken)
    => await _mediator.Send(new GuestLoginCommand(guestName), cancellationToken);
}