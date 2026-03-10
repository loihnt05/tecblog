using BlogPlatform.Application.Interfaces;
using BlogPlatform.Application.Posts.DTOs;
using MediatR;

namespace BlogPlatform.Application.Posts.Queries.GetPosts;

public class GetPostsHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPostsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _unitOfWork.Posts.GetPublishedPostsAsync();
        
        return posts.Select(p => new PostDto
        {
            Id = p.Id,
            Title = p.Title,
            Slug = p.Slug,
            Summary = p.Summary,
            Content = p.Content,
            PublicationDate = p.PublicationDate,
            AuthorName = p.Author.Username
        }).ToList();
    }
}