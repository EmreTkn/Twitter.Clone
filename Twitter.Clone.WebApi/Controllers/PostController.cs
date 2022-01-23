using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Twitter.Clone.Handlers.DTOs;
using Twitter.Clone.Handlers.Post.Commands.CreatePost;
using Twitter.Clone.Handlers.Post.Commands.LikePost;
using Twitter.Clone.Handlers.Post.Queries.GetPosts;
using Twitter.Clone.WebApi.Extensions;
using Twitter.Clone.WebApi.Helpers;

namespace Twitter.Clone.WebApi.Controllers;
public class PostController : BaseApiController
{
    readonly IMediator _mediator;

    public PostController(IMediator mediator) => _mediator = mediator;

    [HttpPost("create")]
    [Authorize]
    public async Task<ActionResult<PostCreatedDto>> Register([FromBody] string postContent, CancellationToken cancellationToken)
        => await _mediator.Send(new CreateNewPostCommand(HttpContext.GetEmailAddress(), postContent), cancellationToken);

    [HttpPost("like")]
    [Authorize]
    public async Task<ActionResult> LikePost([FromBody] string postId, CancellationToken cancellationToken)
        => Ok(await _mediator.Send(new LikePostCommand(HttpContext.GetEmailAddress(), postId), cancellationToken));

    [HttpGet]
    [Authorize]
    [Cached(600)]
    public async Task<ActionResult> GetPosts(int pageNumber, int? pageSize, CancellationToken cancellationToken)
        => Ok(await _mediator.Send(new GetPostsQuery(HttpContext.GetEmailAddress(), pageNumber, pageSize), cancellationToken));
}
