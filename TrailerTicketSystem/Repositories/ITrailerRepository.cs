namespace TrailerTicketSystem.Repositories
{
    public interface ITrailerRepository
    {
        Task<List<Data.Trailer>> GetAllAsync();
    }
}
