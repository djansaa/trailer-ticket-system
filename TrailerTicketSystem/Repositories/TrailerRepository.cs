using Microsoft.EntityFrameworkCore;
using TrailerTicketSystem.Data;

namespace TrailerTicketSystem.Repositories
{
    public class TrailerRepository : ITrailerRepository
    {
        private readonly IDbContextFactory<AppDbContext> _cf;

        public TrailerRepository(IDbContextFactory<AppDbContext> cf)
        {
            _cf = cf;
        }

        public async Task<List<Trailer>> GetAllAsync()
        {
            using (var db = await _cf.CreateDbContextAsync())
            {
                return await db.Trailers
                    .AsNoTracking()
                    .Include(t => t.State)
                    .ToListAsync();
            }
        }
    }
}
