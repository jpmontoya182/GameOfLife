namespace Application.Game.Commands.CreateGame
{
    public class CreateGameResponse
    {
        public Guid GameId { get; set; }
        public List<int[]>? NewBoard { get; set; }
    }
}
