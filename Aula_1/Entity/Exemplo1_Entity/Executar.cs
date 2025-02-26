using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Para usar o entity Framework, a gente vai executar esses comandos no terminal
//dotnet add package Microsoft.EntityFrameworkCore
//dotnet add package Microsoft.EntityFrameworkCore.Design
//dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

namespace Exemplo1_Entity
{
    public class Executar
    {
        static void Main(string[] args)
        {
            Crud crud = new Crud();
            crud.ListarUsuarios();
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Inserindo usuarios");
            crud.InserirUsuario(7, "Fulano", "fulano@gmail.com");
            crud.ListarUsuarios();
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Atualizar usuarios");
            crud.AtualizarUsuario(7, "Fulano da Silva");
            crud.ListarUsuarios();
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Deletando usuarios");
            crud.DeletarUsuario(7);
            crud.ListarUsuarios();
            System.Console.WriteLine("-----------------");

            crud.ListarUsuarios();
        }
    }
}