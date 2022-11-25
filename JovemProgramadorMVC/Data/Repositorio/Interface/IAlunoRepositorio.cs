using JovemProgramadorMVC.Models;
using System.Collections.Generic;

namespace JovemProgramadorMVC.Data.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        AlunoModel BuscarId(int id);
        void InserirAluno(AlunoModel alunos);
        List<AlunoModel> BuscarAlunos();
        AlunoModel Atualizar(AlunoModel aluno);
        bool Apagar(int id);
    }
}
