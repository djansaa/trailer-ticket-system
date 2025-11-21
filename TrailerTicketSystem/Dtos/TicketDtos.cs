namespace TrailerTicketSystem.Dtos
{
    public record TicketDto(
        int TrailerId,
        DateTimeOffset ReportedAt, 
        DateTimeOffset? FixedAt, 
        string ReportNote,
        string? FixNote,
        int AuthorId,
        int? MechanicId);
}
