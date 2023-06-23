﻿using AdotePetInnovation.Models;
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

        public IActionResult Doar()
        {
            return View();
        }

        public IActionResult Conta()
        {
            return View();
        }

        public IActionResult Pets()
        {
            return View();
        }

        public IActionResult Info(string Id)
        {
            var dog = _publicarRepository.GetByIdAsync(Id).Result;

            return View(dog);
        }

        [HttpPost]
        public IActionResult Publicar(PublicarRequest model)
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
            return new JsonResult(model);
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
