namespace TrailerTicketSystem.Data
{
    public sealed class Trailer
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public int StateId { get; set; }

        public State State { get; set; } = null!;
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
