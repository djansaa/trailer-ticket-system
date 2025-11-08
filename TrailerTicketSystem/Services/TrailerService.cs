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
    }
}
