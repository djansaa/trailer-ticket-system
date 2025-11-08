namespace TrailerTicketSystem.Models
{
    public sealed class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public ICollection<Ticket> TicketsAuthored { get; set; } = new List<Ticket>();
        public ICollection<Ticket> TicketsRepaired { get; set; } = new List<Ticket>();
    }
}
