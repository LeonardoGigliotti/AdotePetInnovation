using AdotePetInnovation.Models;
using AdotePetInnovation.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdotePetInnovation.Controllers
{
    public class SignupController : Controller
    {
        private readonly IUserRepository _repo;
        public SignupController(IUserRepository repo)
        {
            _repo = repo;
        }
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        // GET: Signup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Signup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SignupViewModel signup)
        {
            await _repo.CreateAsync(new User {Name = signup.Name, Email = signup.Email, Password = signup.Password});
            return View();
        }

        // GET: Signup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Signup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Signup/Delete/5
        public ActionResult Delete(int id)
        {
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
