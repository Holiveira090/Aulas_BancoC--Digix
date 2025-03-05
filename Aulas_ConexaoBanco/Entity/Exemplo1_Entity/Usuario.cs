using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema; // importa a biblioteca para usar a anotação table, ou seja para definir o nome da tabela

namespace Exemplo1_Entity
{
    [Table("usuario")] // Define explicitamente o nome da tabela
    public class Usuario
    {
        [Column("id")] // Define explicitamente o nome da coluna
        public int Id { get; set; }
        [Column("nome")] // Define explicitamente o nome da coluna
        public string Nome { get; set; } = string.Empty; // valor padrao q evita o campo ser nulo
        [Column("email")] // Define explicitamente o nome da coluna
        public string Email { get; set; } = string.Empty;
    }
}