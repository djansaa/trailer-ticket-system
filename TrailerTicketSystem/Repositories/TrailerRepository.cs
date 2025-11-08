using Microsoft.EntityFrameworkCore;
using TrailerTicketSystem.Data;
using TrailerTicketSystem.Models;

namespace TrailerTicketSystem.Repositories
{
    public class TrailerRepository : ITrailerRepository
    {
        private readonly IDbContextFactory<AppDbContext> _cf;

        public TrailerRepository(IDbContextFactory<AppDbContext> cf)
        {
            _cf = cf;
        }

        public async Task<IReadOnlyList<Trailer>> GetAllAsync(CancellationToken ct = default)
        {
            using (var db = await _cf.CreateDbContextAsync(ct))
            {
                return await db.Trailers
                    .AsNoTracking()
                    .Include(t => t.State)
                    .ToListAsync(ct);
            }
        }
    }
}
