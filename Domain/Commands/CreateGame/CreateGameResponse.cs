using Domain.Entities;

namespace Domain.Commands.CreateGame;

public record CreateGameResponse : ResponseBase
{
    public CreateGameResponse(Guid GameId, List<int[]>? NewBoard, string Message) : base(GameId, NewBoard, Message)
    {
    }
}

