﻿using CadastroDeContatos.Data.Map;
using CadastroDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeContatos.Data
{
    public class ContatoContext:DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> options):base(options)
        {
            
        }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
