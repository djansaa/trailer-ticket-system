using Microsoft.EntityFrameworkCore;
using TrailerTicketSystem.Data;
using TrailerTicketSystem.Models;

namespace TrailerTicketSystem.Repositories
{
    public class TrailerRepository : ITrailerRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public TrailerRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyList<Trailer>> GetAllAsync(CancellationToken ct = default)
        {
            using (var db = await _contextFactory.CreateDbContextAsync(ct))
            {
                return await db.Trailers
                    .AsNoTracking()
                    .Include(t => t.State)
                    .ToListAsync(ct);
            }
        }
    }
}
