using TrailerTicketSystem.Models;

namespace TrailerTicketSystem.Repositories
{
    public interface ITicketRepository
    {
        Task<IReadOnlyList<Ticket>> GetAllAsync(CancellationToken ct);
    }
}
