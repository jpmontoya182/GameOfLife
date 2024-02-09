using MediatR;

namespace Domain.Commands.NextBoard;

public record NextBoardRequest (Guid GameId, int NumberOfBoards) : IRequest<NextBoardResponse>;
