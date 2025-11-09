using TrailerTicketSystem.Dtos;

namespace TrailerTicketSystem.Services
{
    public interface ITrailerService
    {
        Task<IReadOnlyList<TrailerDto>> GetAllAsync(CancellationToken ct = default);
    }
}
