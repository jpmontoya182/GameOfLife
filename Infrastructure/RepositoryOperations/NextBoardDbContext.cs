using Application.Common.Interfaces;
using Application.Game.Commands.GetNextBoard;
using Domain.Entities;
using Infrastructure.Repository;
using System.Text;
using Game = Infrastructure.Models.Game;

namespace Infrastructure.RepositoryOperations;

public class NextBoardDbContext : INextBoardDbContext
{
    private readonly ApplicationDbContext _applicationDbContext;

    public NextBoardDbContext(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public List<int[]> GetBoard(Guid GameId)
    {
        var id = Guid.Parse(GameId.ToString().ToUpper());
        try
        {
            var query = _applicationDbContext.Games
                .OrderByDescending(x => x.Id)
                .FirstOrDefault(b => b.GameId == id);

            var cols = query.Columns;
            var rows = query.Rows;
            var Board = query.GameBoard.ToCharArray();
            List<int[]> board = new List<int[]>();
            List<int> board2 = new List<int>();
            int eval = 1;
           
            for (int i = 0; i < Board.Length; i++)
            {
                board2.Add((int)Char.GetNumericValue(Board[i]));
                eval = i + 1;
                if (eval % cols == 0)
                {
                    board.Add(board2.ToArray());
                    board2.Clear();
                }
            }
            return board;                            
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            return new List<int[]> { };
        }
    }

    public NextBoardResponse UpdateBoard(Guid gameId, List<int[]> board)
    {
        List<int[]> newBoard = board.ToList();
        int totalLenghtY = newBoard[0].Length;
        int totalLenghtX = board.Count();
        var sb = new StringBuilder();

        try
        {
            for (var x = 0; x < newBoard.Count(); x++)
            {
                for (int y = 0; y < newBoard[x].Length; y++)
                {
                    sb.Append(newBoard[x][y].ToString());
                }
            }

            var record = new Game
            {
                GameBoard = sb.ToString(),
                GameId = gameId,
                DateAndTimeCreated = DateTime.Now,
                Rows = totalLenghtX,
                Columns = totalLenghtY
            };
            _applicationDbContext.Games.Add(record);
            _applicationDbContext.SaveChanges();

            return new NextBoardResponse { GameId = record.GameId, NewBoard = newBoard };
        }
        catch(Exception error) 
        {
            throw error;
            // return new NextBoardResponse() { };       
        }

    }

    public List<Games> GetLastGames(Guid gameId, int numberOfTries = 3) 
    {
        var games = new List<Games>();

        var result = _applicationDbContext.Games
            .Where(g => g.GameId == gameId)
            .OrderByDescending(x => x.Id)
            .Take(numberOfTries)
            .ToList();

        // *** create a mapper
        games = result.Select(g => new Games()
        {
            Id = g.Id,
            GameId = g.GameId,
            GameBoard = g.GameBoard,
            DateAndTimeCreated = g.DateAndTimeCreated,
            Rows = g.Rows,
            Columns = g.Columns
        }).ToList();

        return games;         
    }
}
