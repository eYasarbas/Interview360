using Interview360.Application.Features.Categories.Commands.UpsertCategory;
using Interview360.Application.Features.Categories.Queries.GetCategories;
using Interview360.Application.Features.Categories.Queries.GetCategoryById;
using Interview360.Domain.Common.Results.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Interview360.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var query = new GetCategoriesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var query = new GetCategoryByIdQuery { Id = id };
        var result = await _mediator.Send(query);

        if (result.Status != StatusTypeEnum.Success)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpsertCategory([FromBody] UpsertCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status != StatusTypeEnum.Success)
            return BadRequest(result);

        return Ok(result);
    }
}