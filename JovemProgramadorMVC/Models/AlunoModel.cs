using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Models
{
    public class AlunoModel
    {

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public object Id { get; internal set; }
    }
}
