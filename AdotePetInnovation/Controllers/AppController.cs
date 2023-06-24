using AdotePetInnovation.Models;
using AdotePetInnovation.Repositories;
using AdotePetInnovation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdotePetInnovation.Controllers
{
    public class AppController : Controller
    {
        private readonly ILogger<AppController> _logger;

        private readonly IPublicarRepository _publicarRepository;
        private readonly IContaRepository _contaRepository;

        public AppController(IPublicarRepository publicarRepository, IContaRepository contarepository, ILogger<AppController> logger)
        {
            _contaRepository = contarepository;
            _publicarRepository = publicarRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var indexViewModel = new IndexViewModel();
            indexViewModel.Dogs = _publicarRepository.GetAllAsync().Result;

            return View(indexViewModel);
        }

        public IActionResult Doar(string Id)
        {
            if (Id == null)
                return View(new Dog());
            else
            {
                var dog = _publicarRepository.GetByIdAsync(Id).Result;

                return View(dog);
            }
        }

        public IActionResult Conta()
        {
            return View();
        }

        public IActionResult Pets()
        {
            var indexViewModel = new IndexViewModel();

            var email = HttpContext.Session.GetString("userEmail");
            indexViewModel.Dogs = _publicarRepository.GetByUserEmailAsync(email).Result;

            return View(indexViewModel);
        }

        public IActionResult Info(string Id)
        {
            var dog = _publicarRepository.GetByIdAsync(Id).Result;

            return View(dog);
        }

        [HttpPost]
        public IActionResult Publicar(PublicarRequest model)
        {
            if (model.id == null)
            {
                _publicarRepository.CreateAsync(new Dog
                {
                    Name = model.nome,
                    Idade = model.idade,
                    Raca = model.raca,
                    Porte = model.porte,
                    Foto = model.foto,
                    Foto1 = model.foto1,
                    Foto2 = model.foto2,
                    Foto3 = model.foto3,
                    Cidade = model.cidade,
                    Estado = model.estado,
                    Celular = model.celular
                });
            }
            else
            {
                var dog = _publicarRepository.GetByIdAsync(model.id).Result;
                dog.Name = model.nome;
                dog.Idade = model.idade;
                dog.Raca = model.raca;
                dog.Porte = model.porte;
                dog.Foto = model.foto;
                dog.Foto1 = model.foto1;
                dog.Foto2 = model.foto2;
                dog.Foto3 = model.foto3;
                dog.Cidade = model.cidade;
                dog.Estado = model.estado;
                dog.Celular = model.celular;

                _publicarRepository.UpdateAsync(dog);
            }
            return new JsonResult(model);
        }

        [HttpDelete]
        public IActionResult Excluir(string Id)
        {
            _publicarRepository.DeleteAsync(Id);
            return new JsonResult(true);
        }

        [HttpPost]
        public IActionResult Conta(ContaRequest model)
        {
            _contaRepository.CreateAsync(new DoadorEAdotante
            {
                Name = model.Nome,
                Email = model.Email,
                Rg = model.Rg,
                Cpf = model.Cpf,
                Celular = model.Celular,
                Cidade = model.Cidade,
                Estado = model.Estado,
                Cep = model.Cep
            });
            return new JsonResult(model);
        }
    }
}
