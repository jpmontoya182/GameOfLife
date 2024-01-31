using Application.Game.Commands.CreateGame;
using Application.Game.Commands.GetNextBoard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class Game: ControllerBase 
{
    private readonly IMediator _mediator;
    public Game(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("NextBoard")]
    public async Task<NextBoardResponse> NextBoard(NextBoardRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpPost]
    public async Task<CreateGameResponse> Post(CreateGameRequest request)
    {
       return await _mediator.Send(request);
    }
}