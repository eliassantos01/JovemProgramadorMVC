using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace JovemProgramadorMVC.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly JovemProgramadorContexto _jovemProgramadorContexto;

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

            if (aluno == null) throw new System.Exception("Houve um erro na atualização das informações do aluno");
            alunoDB.Nome = aluno.Nome;
            alunoDB.Idade = aluno.Idade;
            alunoDB.Contato = aluno.Contato;
            alunoDB.Email = aluno.Email;
            alunoDB.Cep = aluno.Cep;

            _jovemProgramadorContexto.Update(alunoDB);
            return alunoDB;
        }
    }
}