using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula_1.Dapper.Exemplo1
{
    // Vamos usar o atributo de mapeamento C# para mapear os campos da tabela usuarios para a classe de usuarios
    [Table("usuario")]
    public class Usuario
    {
         [Column("id")] // Define explicitamente o nome da tabela
        public int Id { get; set; }
        [Column("nome")] // Define explicitamente o nome da tabela
        public string Nome { get; set; } = string.Empty; // valor padrao q evita o campo ser nulo
        [Column("email")] // Define explicitamente o nome da tabela
        public string Email { get; set; } = string.Empty;
    }
}