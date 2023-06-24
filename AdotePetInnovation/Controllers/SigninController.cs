using AdotePetInnovation.Repositories;
using AdotePetInnovation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdotePetInnovation.Controllers
{
    public class SigninController : Controller
    {
        private readonly ILogger<SigninController> _logger;
        private readonly IUserRepository _repo;

        public SigninController(IUserRepository repo, ILogger<SigninController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET: Signup
        public ActionResult Login()
        {
            return View();
        }

        // POST: Signup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(SigninViewModel signin)
        {
            var user = await _repo.GetByEmailAsync(signin.Email ?? throw new Exception("usuario/senha invalido"));
            if (user != null && user.Password == signin.Password)
            {
                HttpContext.Session.SetString("userId", user?.Id ?? String.Empty);
                HttpContext.Session.SetString("userName", user?.Name ?? String.Empty);
                HttpContext.Session.SetString("userEmail", user?.Email ?? String.Empty);
                return RedirectToAction("Index", "App");
            }
            ModelState.AddModelError("email", "usuario/senha invalido");
            return View();
        }

        // POST: Signup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
