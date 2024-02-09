namespace Domain.Entities;

public record ResponseBase(Guid GameId, List<int[]>? NewBoard, string Message);
