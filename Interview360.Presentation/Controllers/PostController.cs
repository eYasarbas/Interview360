using Interview360.Application.Features.Posts.Commands.AddComment;
using Interview360.Application.Features.Posts.Commands.LikePost;
using Interview360.Application.Features.Posts.Commands.SavePost;
using Interview360.Application.Features.Posts.Commands.UpsertPost;
using Interview360.Application.Features.Posts.Queries.GetPost;
using Interview360.Application.Features.Posts.Queries.GetPosts;
using Interview360.Domain.Common.Results.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Interview360.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts([FromQuery] GetPostsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(Guid id)
    {
        var query = new GetPostQuery { Id = id };
        var result = await _mediator.Send(query);

        if (result.Status != StatusTypeEnum.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpsertPost([FromBody] UpsertPostCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status != StatusTypeEnum.Success)
            return BadRequest(result);

        return Ok(result);
    }


    [HttpPost("{id}/like")]
    public async Task<IActionResult> LikePost(Guid id, [FromBody] LikePostCommand command)
    {
        command = command with { PostId = id };
        var result = await _mediator.Send(command);
        if (result.Status != StatusTypeEnum.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("{id}/save")]
    public async Task<IActionResult> SavePost(Guid id, [FromBody] SavePostCommand command)
    {
        command = command with { PostId = id };
        var result = await _mediator.Send(command);
        if (result.Status != StatusTypeEnum.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("{id}/comment")]
    public async Task<IActionResult> AddComment(Guid id, [FromBody] AddCommentCommand command)
    {
        command = command with { PostId = id };
        var result = await _mediator.Send(command);
        if (result.Status != StatusTypeEnum.Success)
            return BadRequest(result);

        return Ok(result);
    }
}