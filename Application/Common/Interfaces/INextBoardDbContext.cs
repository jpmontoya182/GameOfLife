using Application.Game.Commands.GetNextBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface INextBoardDbContext
    {
        List<int[]> GetBoard(Guid GameId);

        NextBoardResponse UpdateBoard(Guid GameId, List<int[]> Board);
    }
}
