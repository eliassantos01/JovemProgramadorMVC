﻿
using JovemProgramadorMVC.Data.Mapeamento;
using JovemProgramadorMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorMVC.Data
{
    public class JovemProgramadorContexto : DbContext
    {
        public JovemProgramadorContexto(DbContextOptions<JovemProgramadorContexto> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new ProfessorMapping());
        }
        public DbSet<AlunoModel> Aluno { get; set; }
        public DbSet<ProfessorModel> Professor { get; set; }
    }
}

