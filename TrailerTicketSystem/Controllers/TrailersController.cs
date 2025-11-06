using Microsoft.AspNetCore.Mvc;

namespace TrailerTicketSystem.Controllers
{
    public class TrailersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
