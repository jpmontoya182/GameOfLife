using Domain.Entities;

namespace Domain.Commands.NextBoard;

public record NextBoardResponse : ResponseBase
{
    public NextBoardResponse(Guid gameId, List<int[]>? newBoard, string message) : base(gameId, newBoard, message)
    {
        
    }
}
