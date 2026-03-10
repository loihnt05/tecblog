using BlogPlatform.Application.Authors.DTOs;
using MediatR;

namespace BlogPlatform.Application.Authors.Queries.GetAuthorById;

public record GetAuthorByIdQuery(Guid Id) : IRequest<AuthorDto>;