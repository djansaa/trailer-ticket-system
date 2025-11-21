using Microsoft.AspNetCore.Mvc;
using TrailerTicketSystem.Dtos;
using TrailerTicketSystem.Repositories;

namespace TrailerTicketSystem.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }


        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var results = await _ticketRepository.GetAllAsync(ct);
            IReadOnlyList<TicketDto> model = results.Select(t => new TicketDto(t.TrailerId, t.ReportedAt, t.FixedAt, t.ReportNote, t.FixNote, t.AuthorId, t.MechanicId)).ToList();
            return View(model);
        }
    }
}
