﻿using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IConfiguration _configuration;

        public AlunosController(IAlunoRepositorio alunoRepositorio, IConfiguration configuration)
        {
            _alunoRepositorio = alunoRepositorio;
            _configuration = configuration;
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

            TempData["MensagemSucesso"] = "Aluno adicionado com sucesso!";

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            AlunoModel aluno = _alunoRepositorio.BuscarId(id);
            return View(aluno);
        }

        public IActionResult Alterar(AlunoModel aluno)
        {
            _alunoRepositorio.Atualizar(aluno);
            TempData["MensagemSucesso"] = "Informações alteradas com sucesso!";
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            _alunoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }


        public IActionResult ApagarConfirmacao(int id)
        {
            AlunoModel aluno = _alunoRepositorio.BuscarId(id);
            return View(aluno);
        }


        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            try
            {
                cep = cep.Replace("-", "");
                EnderecoModel enderecoModel = new();

                using var client = new HttpClient();

                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");
                if (result.IsSuccessStatusCode)
                {
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
                }

                return View("Endereco", enderecoModel);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro na conexão com o banco de dados. Por favor tente mais tarde";
                return View();
            }

            
        }


    }
}
