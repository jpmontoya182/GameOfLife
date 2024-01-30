using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Game.Commands.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameRequest, CreateGameResponse>
{
    private readonly ICreateGameDbContext _context;
    private readonly ICalculatedNewBoard _calculatedNewBoard;

    public CreateGameCommandHandler(ICreateGameDbContext context, ICalculatedNewBoard calculatedNewBoard)
    {
        _context = context;
        _calculatedNewBoard = calculatedNewBoard;
    }

    public Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
    {
        var result = _calculatedNewBoard.ProcessBoard(request.Board);

        var responseDb =  _context.SaveBoard(result);

        return Task.FromResult(responseDb);
    }
}