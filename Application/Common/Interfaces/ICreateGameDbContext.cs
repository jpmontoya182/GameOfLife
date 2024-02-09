using Domain.Commands.CreateGame;

namespace Application.Common.Interfaces;

public interface ICreateGameDbContext
{
    CreateGameResponse SaveBoard(CreateGameResponse board);
}