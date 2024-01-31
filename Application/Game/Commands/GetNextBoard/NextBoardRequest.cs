using Application.Common.Interfaces;
using MediatR;


namespace Application.Game.Commands.GetNextBoard
{
    public class NextBoardRequest: IRequest<NextBoardResponse>
    { 
        public Guid GameId { get; set; }
        public int numberOfBoards { get; set;}
    }
}
