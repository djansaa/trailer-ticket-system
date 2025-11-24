using Microsoft.EntityFrameworkCore;
using TrailerTicketSystem.Data;
using TrailerTicketSystem.Models;

namespace TrailerTicketSystem.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public AppUserRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<AppUser?> GetUserByNameAsync(string userName, CancellationToken ct)
        {
            using (var db = await _contextFactory.CreateDbContextAsync(ct))
            {
                return await db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Name == userName);
            }
        }
    }
}
