using System.ComponentModel.DataAnnotations;
using System.Security;
using Application.Common.Interfaces;
using Domain.Entities;  
using MediatR;

namespace Application.Game.Commands.CreateGame;

public record CreateGameCommand: IRequest<GameItem>
{
    public GameItem? Board { get; init; }
}

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameItem>
{
    private readonly IApplicationDbContext _context;
    private readonly ICalculatedNewBoard _calculatedNewBoard;

    public CreateGameCommandHandler(IApplicationDbContext context, ICalculatedNewBoard calculatedNewBoard)
    {
        _context = context;
        _calculatedNewBoard = calculatedNewBoard;
    }

    public async Task<GameItem> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        // calcular siguiente board
        var result = _calculatedNewBoard.ProcessBoard(request.Board);

        _context.SaveBoard(result);

        await _context.SaveChangesAsync(cancellationToken);

        throw new NotImplementedException();
    }
}