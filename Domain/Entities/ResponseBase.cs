namespace Domain.Entities;

public class ResponseBase
{
    public Guid GameId { get; set; }
    public List<int[]>? NewBoard { get; set; }
}
