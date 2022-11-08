using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;

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
    }
}
