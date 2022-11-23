using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly JovemProgramadorContexto _jovemProgramadorContexto;
        private readonly IConfiguration _configuration;

        public AlunoRepositorio(JovemProgramadorContexto jovemProgramadorContexto)
        {
            _jovemProgramadorContexto = jovemProgramadorContexto;
        }

        public void InserirAluno(AlunoModel alunos)
        {
            _jovemProgramadorContexto.Aluno.Add(alunos);
            _jovemProgramadorContexto.SaveChanges();
        }

        public List<AlunoModel> BuscarAlunos()
        {
            return _jovemProgramadorContexto.Aluno.ToList();

        }
        public AlunoModel BuscarId(int id)
        {
            return _jovemProgramadorContexto.Aluno.FirstOrDefault(x => x.Id == id);
        }

        public AlunoModel Atualizar(AlunoModel aluno)
        {
            AlunoModel alunoDB = BuscarId(aluno.Id);

            if (alunoDB == null) throw new System.Exception("Houve um erro na atualização das informações do aluno");

            alunoDB.Nome = aluno.Nome;
            alunoDB.Idade = aluno.Idade;
            alunoDB.Contato = aluno.Contato;
            alunoDB.Email = aluno.Email;
            alunoDB.Cep = aluno.Cep;

            _jovemProgramadorContexto.Update(alunoDB);
            _jovemProgramadorContexto.SaveChanges();

            return alunoDB;
        }

        public bool Apagar(int id)
        {
            AlunoModel alunoDB = BuscarId(id);

            if (alunoDB == null) throw new System.Exception("Erro. Não foi possível remover o registro do aluno");

            _jovemProgramadorContexto.Remove(alunoDB);
            _jovemProgramadorContexto.SaveChanges();
            return true;
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            EnderecoModel enderecoModel = new();

            using var client = new HttpClient();

            var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");
            if (result.IsSuccessStatusCode)
            {
                enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
            }

            return View();

        }

    }
}