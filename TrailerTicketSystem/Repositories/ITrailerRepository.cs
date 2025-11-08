using TrailerTicketSystem.Models;

namespace TrailerTicketSystem.Repositories
{
    public interface ITrailerRepository
    {
        Task<IReadOnlyList<Trailer>> GetAllAsync(CancellationToken ct);
    }
}
