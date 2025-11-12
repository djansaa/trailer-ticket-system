using Microsoft.AspNetCore.Mvc;
using TrailerTicketSystem.Dtos;
using TrailerTicketSystem.Repositories;

namespace TrailerTicketSystem.Controllers
{
    public class TrailersController : Controller
    {
        private readonly ITrailerRepository _trailerRepository;

        public TrailersController(ITrailerRepository trailerRepository)
        {
            _trailerRepository = trailerRepository;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var results = await _trailerRepository.GetAllAsync(ct);
            var model = results.Select(t => new TrailerDto(t.Id, t.LicensePlate, t.StateId)).ToList();

            return View(model);
        }
    }
}
