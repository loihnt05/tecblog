using BlogPlatform.Application.Interfaces;
using BlogPlatform.Domain.Enities;
using MediatR;

namespace BlogPlatform.Application.Posts.Commands.CreatePost;

public class CreatePostHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePostCommand command, CancellationToken cancellationToken)
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

        await _unitOfWork.Posts.AddAsync(post);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return post.Id;
    }
}