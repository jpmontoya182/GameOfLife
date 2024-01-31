using Application.Common.Interfaces;
using Application.Game.Commands.CreateGame;
using MediatR;

namespace Application.Game.Commands.GetNextBoard
{
    public class NextBoardCommandHandler : IRequestHandler<NextBoardRequest, NextBoardResponse>
    {
        private readonly INextBoardDbContext _context;
        private readonly ICalculatedNewBoard _calculatedNewBoard;
        private readonly ICreateGameDbContext _createGameDbContext;
        private readonly ICreateGameDbContext _saveContext;

        public NextBoardCommandHandler(
            INextBoardDbContext context, 
            ICalculatedNewBoard calculatedNewBoard, 
            ICreateGameDbContext createGameDbContext,
            ICreateGameDbContext saveContext
            )
        {
            _context = context;
            _calculatedNewBoard = calculatedNewBoard;
            _createGameDbContext = createGameDbContext;
            _saveContext = saveContext;
    }

        public Task<NextBoardResponse> Handle(NextBoardRequest request, CancellationToken cancellationToken)
        {
            CreateGameResponse boardResult = new CreateGameResponse();
            var boardFromDB = _context.GetBoard(request.GameId);


            var lastBoardCalculated = _calculatedNewBoard.ProcessBoard(boardFromDB, request.numberOfBoards);   
            
            /// se creo uno nuevo se necesita reemplazar
            var responseDb = _context.UpdateBoard(request.GameId, lastBoardCalculated.NewBoard);

            return Task.FromResult( new NextBoardResponse() { GameId = request.GameId, NewBoard = responseDb.NewBoard }); 
        }
    }

}
