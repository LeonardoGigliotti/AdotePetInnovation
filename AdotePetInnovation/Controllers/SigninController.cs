using AdotePetInnovation.Models;
using AdotePetInnovation.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdotePetInnovation.Controllers
{
    public class SigninController : Controller
    {
        private readonly ILogger<SigninController> _logger;

        private readonly IUserRepository _repo;
        public SigninController(IUserRepository repo
, ILogger<SigninController> logger            )
        {
            _repo = repo;
            _logger = logger;
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
        public async Task<ActionResult> Login(SigninViewModel signin)
        {
            var user = await _repo.GetByEmailAsync(signin.Email);
            if(user.Password == signin.Password){
                return RedirectToAction("B",
                        "FileUploadMsgView",
                        new { FileUploadMsg = "File uploaded successfully" });
            }
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
