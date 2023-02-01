using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaCadastro.Models;
using SistemaCadastro.Repository;
using SistemaCadastro.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastro.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ILogger<ContatoController> _logger;
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(ILogger<ContatoController> logger, IContatoRepository contatoRepository)
        {
            _logger = logger;
            _contatoRepository = contatoRepository;
        }

       

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            ContatoModel person = new ContatoModel();
            person.Nome = "Rafael";
            return View(person);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Cadastrar(ContatoModel contato)
        {
           _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
