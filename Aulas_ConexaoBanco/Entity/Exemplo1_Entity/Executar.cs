using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

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
            Stopwatch sw = new Stopwatch();
            Crud crud = new Crud();
            TimeSpan TempoTotal;
            sw.Start();
            crud.ListarUsuarios();
            sw.Stop(); // para o cronometro
            TimeSpan tempoLeitura = sw.Elapsed;
            System.Console.WriteLine($"Tempo para listar: {sw.ElapsedMilliseconds}ms");
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Inserindo usuarios");
            sw.Restart();
            crud.InserirUsuario(7, "Fulano", "fulano@gmail.com");
            sw.Stop(); // para o cronometro
            TimeSpan tempoInsercao = sw.Elapsed;
            System.Console.WriteLine($"Tempo para inserir: {sw.ElapsedMilliseconds}ms");
            crud.ListarUsuarios();
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Atualizar usuarios");
            sw.Restart();
            crud.AtualizarUsuario(7, "Fulano da Silva");
            sw.Stop(); // para o cronometro
            System.Console.WriteLine($"Tempo para atualizar: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoAtualizacao = sw.Elapsed;
            crud.ListarUsuarios();
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Deletando usuarios");
            sw.Restart();
            crud.DeletarUsuario(7);
            sw.Stop(); // para o cronometro
            System.Console.WriteLine($"Tempo para deletar: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoDelete = sw.Elapsed;
            crud.ListarUsuarios();
            System.Console.WriteLine("-----------------");

            crud.ListarUsuarios();
            TempoTotal = tempoInsercao + tempoLeitura + tempoAtualizacao + tempoDelete;

            System.Console.WriteLine($"tempo total {TempoTotal}");
        }
    }
}