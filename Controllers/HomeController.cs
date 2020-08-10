using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Asp.net.Models;

namespace Asp.net.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetalhePesquisa()
        {
            return View("DetalhePesquisa");
        }

        [HttpPost]
        public IActionResult Detalhe(Aluno aluno)
        {
            List<Aluno> todosAlunos = BaseDeDados.Listar();
            List<Aluno> Filtrado = todosAlunos.FindAll( e => e.Nome == aluno.Nome);
            return View(Filtrado);

        }
        
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Concluido(Aluno aluno)
        {
            BaseDeDados.Incluir(aluno);
            ViewBag.Nome = aluno.Nome;
            ViewBag.Disciplina = aluno.Disciplina;
            ViewBag.Nota = aluno.Nota;
            return View("Concluido");
        }

        public IActionResult Listagem()
        {
            List<Aluno> alunos = BaseDeDados.Listar();
            return View(alunos);
        }

        public IActionResult About()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
