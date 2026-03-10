using BlogPlatform.Application.Posts.Commands.CreatePost;
using BlogPlatform.Application.Posts.Queries.GetPostById;
using BlogPlatform.Application.Posts.Queries.GetPostBySlug;
using BlogPlatform.Application.Posts.Queries.GetPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.API.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var post = await _mediator.Send(new GetPostByIdQuery(id));
        
        if (post == null)
            return NotFound();
            
        return Ok(post);
    }

    [HttpGet("slug/{slug}")]
    public async Task<IActionResult> GetBySlug(string slug)
    {
        var post = await _mediator.Send(new GetPostBySlugQuery(slug));
        
        if (post == null)
            return NotFound();
            
        return Ok(post);
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _mediator.Send(new GetPostsQuery());
        return Ok(posts);
    }
}