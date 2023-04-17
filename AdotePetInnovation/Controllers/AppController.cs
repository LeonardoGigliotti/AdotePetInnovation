using Microsoft.AspNetCore.Mvc;

namespace AdotePetInnovation.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Doar()
        {
            return View();
        }

    }
}
