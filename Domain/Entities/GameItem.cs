namespace Domain.Entities;

public class GameItem
{
    public IEnumerable<int[]> Board { get; set; }
    public int NumberOfStates { get; set; }
    public Guid GameId { get; set; }
}