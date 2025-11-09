using TrailerTicketSystem.Dtos;
using TrailerTicketSystem.Models;
using TrailerTicketSystem.Repositories;

namespace TrailerTicketSystem.Services
{
    public class TrailerService : ITrailerService
    {
        private readonly ITrailerRepository _trailerRepository;

        public TrailerService(ITrailerRepository trailerRepository)
        {
            _trailerRepository = trailerRepository;
        }

        public async Task<IReadOnlyList<TrailerDto>> GetAllAsync(CancellationToken ct = default)
        {
            var entities = await _trailerRepository.GetAllAsync(ct);
            return entities.Select(t => new TrailerDto(t.Id, t.LicensePlate, t.StateId)).ToList();
        }
    }
}
