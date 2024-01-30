using Application.Game.Commands.CreateGame;

namespace Application.Common.Interfaces;

public interface ICreateGameDbContext
{
    CreateGameResponse SaveBoard(CreateGameResponse board);
}