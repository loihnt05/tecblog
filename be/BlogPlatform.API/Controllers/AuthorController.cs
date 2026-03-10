using BlogPlatform.Application.Authors.Commands.CreateAuthor;
using BlogPlatform.Application.Authors.Queries.GetAuthorById;
using BlogPlatform.Application.Authors.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.API.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, id);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery(id));
        if (author == null)
            return NotFound();
            
        return Ok(author);
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _mediator.Send(new GetAuthorsQuery());
        return Ok(authors);
    }
}