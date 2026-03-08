using MediatR;

namespace BlogPlatform.Application.Posts.Commands.CreatePost;

public record CreatePostCommand(
    string Title,
    string Content,
    string? Summary,
    Guid AuthorId
) : IRequest<Guid>;