using BlogPlatform.Application.Authors.DTOs;
using MediatR;

namespace BlogPlatform.Application.Authors.Queries.GetAuthors;

public record GetAuthorsQuery : IRequest<List<AuthorDto>>;