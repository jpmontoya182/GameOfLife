using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repository
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public Guid SaveBoard(GameItem board)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
