using JovemProgramadorMVC.Models;
using System.Collections.Generic;

namespace JovemProgramadorMVC.Data.Repositorio.Interface
{
    public interface IProfessorRepositorio
    {
        ProfessorModel BuscarId(int id);
        void InserirProfessor(ProfessorModel professores);
        List<ProfessorModel> BuscarProfessores();
        ProfessorModel Atualizar(ProfessorModel professor);
        bool Apagar(int id);
    }
}
