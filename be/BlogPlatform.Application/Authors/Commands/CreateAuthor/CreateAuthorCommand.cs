using MediatR;

namespace BlogPlatform.Application.Authors.Commands.CreateAuthor;

public record CreateAuthorCommand(
    string Username,
    string Email,
    string Password,
    string? Bio,
    string? AvatarUrl
) : IRequest<Guid>;