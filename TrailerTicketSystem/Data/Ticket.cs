namespace TrailerTicketSystem.Data
{
    public sealed class Ticket
    {
        // Composite PK: (TrailerId, ReportedAt)
        public int TrailerId { get; set; }
        public DateTimeOffset ReportedAt { get; set; }
        public DateTimeOffset? FixedAt { get; set; }

        public string ReportNote { get; set; } = string.Empty;
        public string? FixNote { get; set; }

        public int AuthorId { get; set; }
        public int? MechanicId { get; set; }

        public Trailer Trailer { get; set; } = null!;
        public AppUser Author { get; set; } = null!;
        public AppUser? Mechanic { get; set; }
    }
}
