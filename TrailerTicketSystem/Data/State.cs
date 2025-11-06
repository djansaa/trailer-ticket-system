namespace TrailerTicketSystem.Data
{
    public sealed class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Trailer> Trailers { get; set; } = new List<Trailer>();
    }
}
