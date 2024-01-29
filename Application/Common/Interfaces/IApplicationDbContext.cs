using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    Guid SaveBoard(GameItem board);

    Task<Guid> SaveChangesAsync(CancellationToken cancellationToken);
}