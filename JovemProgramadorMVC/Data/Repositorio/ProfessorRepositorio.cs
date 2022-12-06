using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace JovemProgramadorMVC.Data.Repositorio
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly JovemProgramadorContexto _jovemProgramadorContexto;

        public ProfessorRepositorio(JovemProgramadorContexto jovemProgramadorContexto)
        {
            _jovemProgramadorContexto = jovemProgramadorContexto;
        }

        public void InserirProfessor(ProfessorModel professores)
        {
            _jovemProgramadorContexto.Professor.Add(professores);
            _jovemProgramadorContexto.SaveChanges();
        }

        public List<ProfessorModel> BuscarProfessores()
        {
            return _jovemProgramadorContexto.Professor.ToList();

        }
        public ProfessorModel BuscarId(int id)
        {
            return _jovemProgramadorContexto.Professor.FirstOrDefault(x => x.Id == id);
        }

        public ProfessorModel Atualizar(ProfessorModel professor)
        {
            ProfessorModel professorDB = BuscarId(professor.Id);

            if (professorDB == null) throw new System.Exception("Houve um erro na atualização das informações do professor");

            professorDB.Nome = professor.Nome;
            professorDB.Idade = professor.Idade;
            professorDB.Contato = professor.Contato;
            professorDB.Email = professor.Email;
            professorDB.Disciplina = professor.Disciplina;
            professorDB.Cep = professor.Cep;

            _jovemProgramadorContexto.Update(professorDB);
            _jovemProgramadorContexto.SaveChanges();

            return professorDB;
        }

        public bool Apagar(int id)
        {
            ProfessorModel professorDB = BuscarId(id);

            if (professorDB == null) throw new System.Exception("Erro. Não foi possível remover o registro do professor");

            _jovemProgramadorContexto.Remove(professorDB);
            _jovemProgramadorContexto.SaveChanges();
            return true;
        }
    }
}