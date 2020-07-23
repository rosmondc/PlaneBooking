using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaneBooking.Web.Services.Contracts;

namespace PlaneBooking.Web.Controllers
{
    public class TutorController : Controller
    {
        private ITutorService _service;
        public TutorController(ITutorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post()
        {
            return View(await _service.GetList());
        }
    }
}
