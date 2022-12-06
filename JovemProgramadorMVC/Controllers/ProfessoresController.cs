using JovemProgramadorMVC.Data.Repositorio.Interface;
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
    public class ProfessoresController : Controller
    {
        private readonly IProfessorRepositorio _professorRepositorio;
        private readonly IConfiguration _configuration;

        public ProfessoresController(IProfessorRepositorio professorRepositorio, IConfiguration configuration)
        {
            _professorRepositorio = professorRepositorio;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var professores = _professorRepositorio.BuscarProfessores();
            return View(professores);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult InserirProfessor (ProfessorModel professores)
        {
            _professorRepositorio.InserirProfessor(professores);

            TempData["MensagemSucesso"] = "Professor adicionado com sucesso!";

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            ProfessorModel professor = _professorRepositorio.BuscarId(id);
            return View(professor);
        }

        public IActionResult Alterar(ProfessorModel professor)
        {
            _professorRepositorio.Atualizar(professor);
            TempData["MensagemSucesso"] = "Informações alteradas com sucesso!";
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            _professorRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }


        public IActionResult ApagarConfirmacao(int id)
        {
            ProfessorModel professor = _professorRepositorio.BuscarId(id);
            return View(professor);
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
