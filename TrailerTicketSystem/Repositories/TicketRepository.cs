using Microsoft.EntityFrameworkCore;
using TrailerTicketSystem.Data;
using TrailerTicketSystem.Models;

namespace TrailerTicketSystem.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public TicketRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyList<Ticket>> GetAllAsync(CancellationToken ct = default)
        {
            using (var db = await _contextFactory.CreateDbContextAsync(ct))
            {
                return await db.Tickets
                    .AsNoTracking()
                    .ToListAsync(ct);
            }
        }
    }
}
