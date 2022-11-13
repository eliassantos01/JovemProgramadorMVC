using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunosController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public IActionResult Index()
        {
            var alunos = _alunoRepositorio.BuscarAlunos();
            return View(alunos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult InserirAluno(AlunoModel alunos)
        {
            _alunoRepositorio.InserirAluno(alunos);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            AlunoModel aluno = _alunoRepositorio.BuscarId(id);
            return View(aluno);
        }

        public IActionResult Alterar(AlunoModel alunos)
        {
            _alunoRepositorio.Atualizar(alunos);
            return RedirectToAction("Index");
        }





        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

       

    }
}
