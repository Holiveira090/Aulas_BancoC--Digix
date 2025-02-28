using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

namespace Exemplo1
{
    public class Executar
    {
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Crud crud = new Crud();
            TimeSpan TempoTotal;


            sw.Start();
            crud.InserirUsuario(4, "Maria", "Maria@gmail.com");
            sw.Stop();
            System.Console.WriteLine($"Tempo para inserir: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoInsercao = sw.Elapsed;


            System.Console.WriteLine("------------------");

            sw.Restart();
            crud.ListarUsuarios();
            sw.Stop();
            System.Console.WriteLine($"Tempo para Listar: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoLeitura = sw.Elapsed;

            System.Console.WriteLine("------------------");

            sw.Restart();
            crud.AtualizarUsuario(4, "joao");
            sw.Stop();
            System.Console.WriteLine($"Tempo para atualizar: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoAtualizacao = sw.Elapsed;

            System.Console.WriteLine("------------------");
            crud.ListarUsuarios();
            System.Console.WriteLine("------------------");

            sw.Restart();
            crud.DeletarUsuario(4);
            sw.Stop();
            System.Console.WriteLine($"Tempo para deletar: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoDeletar = sw.Elapsed;

            TempoTotal = tempoInsercao + tempoLeitura + tempoAtualizacao + tempoDeletar;

            System.Console.WriteLine($"tempo total {TempoTotal}");
        }
    }
}