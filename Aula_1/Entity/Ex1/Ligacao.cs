using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ex1
{
    public class Ligacao : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<Maquina> Maquina { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //  aqui será configurada a conexão com o banco de dados
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=ExEntity;Username=postgres;Password=master"); // aqui é passado a string de conexão com o banco de dados
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder. Entity<Maquina>() . ToTable("maquina");
            modelBuilder. Entity<Software>().ToTable("software");
        }
    }
}