using BlogPlatform.Application.Posts.DTOs;
using MediatR;

namespace BlogPlatform.Application.Posts.Queries.GetPosts;

public record GetPostsQuery() : IRequest<List<PostDto>>;