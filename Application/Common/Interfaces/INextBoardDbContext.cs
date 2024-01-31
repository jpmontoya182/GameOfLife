using Application.Game.Commands.GetNextBoard;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface INextBoardDbContext
{
    List<int[]> GetBoard(Guid GameId);

    NextBoardResponse UpdateBoard(Guid GameId, List<int[]> Board);

    List<Games> GetLastGames(Guid gameId, int numberOfTries = 3);
}
