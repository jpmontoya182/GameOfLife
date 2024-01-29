using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ICalculatedNewBoard{
    public GameItem ProcessBoard(GameItem board);
}