﻿using JovemProgramadorMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Data.Mapeamento
{
    public class ProfessorMapping : IEntityTypeConfiguration<ProfessorModel>
    {
        public void Configure(EntityTypeBuilder<ProfessorModel> builder)
        {
            builder.ToTable("Professor");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasColumnType("varchar(100)");
            builder.Property(t => t.Idade).HasColumnType("int");
            builder.Property(t => t.Contato).HasColumnType("varchar(50)");
            builder.Property(t => t.Email).HasColumnType("varchar(50)");
            builder.Property(t => t.Disciplina).HasColumnType("varchar(100)");
            builder.Property(t => t.Cep).HasColumnType("varchar(20)");
        }

    }
}
