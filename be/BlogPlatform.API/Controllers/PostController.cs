using BlogPlatform.Application.Posts.Commands.CreatePost;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.API.Controllers;
[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly CreatePostHandler _createHandler;

    public PostController(CreatePostHandler createHandler)
    {
        _createHandler = createHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostCommand command)
    {
        var id = await _createHandler.Handle(command);
        return Ok(id);
    }
}