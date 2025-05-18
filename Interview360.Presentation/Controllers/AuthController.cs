using Interview360.Application.Features.Auth.Commands.Login;
using Interview360.Application.Features.Auth.Commands.Logout;
using Interview360.Application.Features.Auth.Commands.Register;
using Interview360.Application.Features.Auth.Commands.ResetPassword;
using Interview360.Domain.Common.Results.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Interview360.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status != StatusTypeEnum.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status != StatusTypeEnum.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status != StatusTypeEnum.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status != StatusTypeEnum.Success)
            return BadRequest(result);

        return Ok(result);
    }
}