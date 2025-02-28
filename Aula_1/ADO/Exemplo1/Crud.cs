using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Diagnostics;

namespace Exemplo1
{
    public class Crud
    {
        // Aqui esta as configurações de conexão com o banco de dados
        string conexao = "Host=localhost;Database=BancoC#1;Username=postgres;Password=master";

        void InserirUsuario(int id, string nome, string email)
        {
            string query = $"Insert into public.usuario (id, nome, email) values ({id}, '{nome}', '{email}')";
            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("id", id); // Parametros para a query, que são os valores que serao inseridos
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        void LerUsuario()
        {
            System.Console.WriteLine("Usuarios");
            string query = "Select * from public.usuario";

            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        { 
                        while (dr.Read()) 
                        {
                            System.Console.WriteLine($"Id: {dr["id"]} Nome: {dr["nome"]} Email: {dr["email"]}");
                        }
                        }
                    }
            }
        }

        void AtualizarUsuario(int id, string nome)
        {
            string query = $"update public.usuario set nome = '{nome}' where id = {id}";

            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.Parameters.AddWithValue("nome", nome);
                        cmd.ExecuteNonQuery();
                    }
            }
        }

        void DeletarUsuario(int id)
        {
            string query = $"Delete from public.usuario where id = {id}";

            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        static void Main(string[] args)
        {
            Crud crud = new Crud();
            Stopwatch sw = new Stopwatch(); // Classe que representa o cronometro para medir o tempo de execução durante a execução do codigo
            TimeSpan TempoTotal; // variavel que vai armazenar o tempo total de execução

            // 1. Medindo o tempo de inserção de um registro
            sw.Start(); // inicia o cronometro
            crud.InserirUsuario(7, "fulano", "fulano@gmail.com");
            sw.Stop(); // para o cronometro
            System.Console.WriteLine($"Tempo de inserção: {sw.ElapsedMilliseconds}ms"); // é o tempo total em milisegundos
            TimeSpan tempoInsercao = sw.Elapsed; // armazena o tempo de inserção

            // 2. medindo o tempo de leitura de um registro
            sw.Restart(); // Reinicia o cronometro
            System.Console.WriteLine("Leitura de registros");
            crud.LerUsuario();
            sw.Stop();
            System.Console.WriteLine($"Tempo de leitura: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoLeitura = sw.Elapsed;

            // 3. medindo tempo de atualização
            sw.Restart();
            System.Console.WriteLine("Atualizações de registros: ");
            crud.AtualizarUsuario(7, "ciclano");
            sw.Stop();
            System.Console.WriteLine($"Tempo de atualização: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoAtualizacao = sw.Elapsed;

            // 4. medindo tempo de delete 
            sw.Restart();
            System.Console.WriteLine("delete de registros: ");
            crud.DeletarUsuario(7);
            sw.Stop();
            System.Console.WriteLine($"Tempo de delete: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoDelete = sw.Elapsed;

            // Calculando o tempo total de execução
            TempoTotal = tempoInsercao + tempoLeitura + tempoAtualizacao + tempoDelete;
            System.Console.WriteLine($"tempo de execução: {TempoTotal}");
        }
    }
}