using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Twitter.Clone.Handlers.Follow.Commands.FollowUser;
using Twitter.Clone.WebApi.Extensions;

namespace Twitter.Clone.WebApi.Controllers;
public class UserController : BaseApiController
{
    readonly IMediator _mediator;
    public UserController(IMediator mediator) => _mediator = mediator;

    [HttpPost("follow")]
    [Authorize]
    public async Task<ActionResult> LikePost([FromBody] string followedUserId, CancellationToken cancellationToken)
        => Ok(await _mediator.Send(new FollowUserCommand(HttpContext.GetEmailAddress(), followedUserId), cancellationToken));
}