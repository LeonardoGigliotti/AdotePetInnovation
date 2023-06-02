using AdotePetInnovation.Models;
using AdotePetInnovation.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdotePetInnovation.Controllers
{
    public class AppController : Controller
    {
        private readonly ILogger<AppController> _logger;

        private readonly IPublicarRepository _repo;
        public AppController(IPublicarRepository repo
, ILogger<AppController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Doar()
        {
            return View();
        }
        public IActionResult Conta()
        {
            return View();
        }
        public IActionResult Mensagens()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Publicar(PublicarRequest model)
        {
            _repo.CreateAsync(new Dog
            {
                Name= model.nome,
                Idade= model.idade,
                Raca= model.raca,
                Porte= model.porte,
                Celular= model.celular
            });
            return new JsonResult(model);
        }
    }
}
