using TrailerTicketSystem.Models;

namespace TrailerTicketSystem.Repositories
{
    public interface IAppUserRepository
    {
        Task<AppUser?> GetUserByNameAsync(string userName, CancellationToken ct);
    }
}
