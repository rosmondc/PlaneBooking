using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaneBooking.Database.ViewModels;
using PlaneBooking.Web.Services.Contracts;
using System.Threading.Tasks;

namespace PlaneBooking.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _service;
        public AccountController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {
            var user = new UserViewModel { Email = email, Password = password };
            var result = _service.Login(user);

            return View();
        }

    }
}
