using BlogPlatform.Application.Interfaces;
using BlogPlatform.Domain.Enities;

namespace BlogPlatform.Application.Posts.Commands.CreatePost;

public class CreatePostHandler
{
    private readonly IPostRepository _repository;

    public CreatePostHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreatePostCommand command)
    {
        var slug = command.Title
            .ToLower()
            .Replace(" ", "-");

        var post = new Post
        {
            Id = Guid.NewGuid(),
            Title = command.Title,
            Slug = slug,
            Content = command.Content,
            Summary = command.Summary,
            AuthorId = command.AuthorId,
            IsPublished = false,
            PublicationDate = DateTime.UtcNow,
            LastModifiedDate = DateTime.UtcNow
        };

        await _repository.AddAsync(post);

        return post.Id;
    }
}