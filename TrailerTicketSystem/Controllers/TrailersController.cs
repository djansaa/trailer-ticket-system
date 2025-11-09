using Microsoft.AspNetCore.Mvc;
using TrailerTicketSystem.Dtos;
using TrailerTicketSystem.Services;

namespace TrailerTicketSystem.Controllers
{
    public class TrailersController : Controller
    {
        private readonly ITrailerService _trailerService;

        public TrailersController(ITrailerService trailerService)
        {
            _trailerService = trailerService;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            IReadOnlyList<TrailerDto> model = await _trailerService.GetAllAsync(ct);
            return View(model);
        }
    }
}
