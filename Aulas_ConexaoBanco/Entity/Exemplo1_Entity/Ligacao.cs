using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Exemplo1_Entity
{
    public class Ligacao : DbContext // Aqui herda a classe principal do Entity Framework
    {
        public DbSet<Usuario> Usuarios { get; set; } // aqui define a tabela que vai ser usada, DbSet é uma coleção de objetos que serão usados. A gente trata como se fosse uma tabela, mas é uma coleção de objetos ou uma lista de objetos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //  aqui será configurada a conexão com o banco de dados
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=BancoC#1;Username=postgres;Password=master"); // aqui é passado a string de conexão com o banco de dados
        }

        // Método para configurar o mapeamento de entidades(tabelas) no banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuario"); // aqui é mapeada a tabela usuario
        } // aqui esta sendo garantido que a tabela usuario vai ser usada para a tabela usuario no banco de dados

    }
}