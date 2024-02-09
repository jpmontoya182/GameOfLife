using Application.Common.Interfaces;
using Domain.Commands.CreateGame;
using MediatR;

namespace Application.Game.Commands.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameRequest, CreateGameResponse>
{
    private readonly ICreateGameDbContext _context;
    private readonly INewBoard _calculatedNewBoard;

    public CreateGameCommandHandler(ICreateGameDbContext context, INewBoard calculatedNewBoard)
    {
        _context = context;
        _calculatedNewBoard = calculatedNewBoard;
    }

    public Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
    {
        if (_calculatedNewBoard.ValidateInput(request.Board))
        {
            return Task.FromResult(
                new CreateGameResponse(
                    GameId: new Guid(), 
                    NewBoard: request.Board.ToList(), 
                    Message: "The Board does not have the same messure."
                )
            );            
        }

        var result = _calculatedNewBoard.CreateNewBoard(request.Board);

        var responseDb =  _context.SaveBoard(result);

        return Task.FromResult(responseDb);
    }
}