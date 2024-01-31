﻿using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Game.Commands.GetNextBoard;

public class NextBoardCommandHandler : IRequestHandler<NextBoardRequest, NextBoardResponse>
{
    private readonly INextBoardDbContext _context;
    private readonly INewBoard _calculatedNewBoard;

    public NextBoardCommandHandler(INextBoardDbContext context,INewBoard calculatedNewBoard)
    {
        _context = context;
        _calculatedNewBoard = calculatedNewBoard;
    }

    public Task<NextBoardResponse> Handle(NextBoardRequest request, CancellationToken cancellationToken)
    {
        NextBoardResponse boardResult = new NextBoardResponse();
        var GameId = request.GameId;
        var numberOfBoards = request.numberOfBoards;
        var boardFromDB = _context.GetBoard(GameId);
        bool hasConclution = true;

        if ( boardFromDB != null || boardFromDB.Count > 0) { 

            for (int i = 0; i < numberOfBoards; i++)
            {
                boardFromDB = _calculatedNewBoard.CreateNewBoard(boardFromDB).NewBoard;
                _context.UpdateBoard(GameId, boardFromDB!);
                boardResult = new NextBoardResponse() { NewBoard = boardFromDB?.ToList(), GameId = GameId };
            }

            // validation of last three results
            List<Games> query = _context.GetLastGames(GameId);
            var countValidation = query
                .GroupBy(x => x.GameBoard)
                .Where(g => g.Count() > 1)
                .Select(g => new { ResultBoard = g.Key, Count = g.Count() });

            foreach (var count in countValidation)
            {
                if (count.Count >= 3)
                {
                    hasConclution = false;
                }
                
            }

            if (!hasConclution)
            {
                boardResult = new NextBoardResponse()
                {
                    NewBoard = new List<int[]>(),
                    GameId = new Guid(),
                    Message = "There is not game conclusion after three tries  :'("
                };

            }

        }
        else
        {
            throw new Exception("Error in the handler of NextBoard");
        }

        return Task.FromResult(boardResult); 
    }
}
