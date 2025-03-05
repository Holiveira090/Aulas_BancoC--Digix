// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Npgsql;

// dotnet add package Npgsql

// namespace Exemplo1
// {
//     public class Executar
//     {
//         static void Main(string[] args)
//         {
//             // Aqui esta as configurações de conexão com o banco de dados
//             string conexao = "Host=localhost;Database=BancoC#1;Username=postgres;Password=master";

//             using (NpgsqlConnection con = new NpgsqlConnection(conexao))
//             {
//                 try
//                 {
//                     con.Open(); // abre a conexao com o banco
//                     System.Console.WriteLine("conexão aberta com postgres");

    
//                     // Vamos criar um comando que vai inserir um novo registro na tabela usuario
//                     string insertQuery = "insert into public.usuario (id, nome, email) values (8, 'João', 'joao@gmail.com')";
//                     using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, con))
//                     {
//                         int row = cmd.ExecuteNonQuery(); // Ele executa um comando que não retorna dados, como insert, update, delete
//                         System.Console.WriteLine($"Linhas afetadas {row}");
//                     }


//                     // Aqui estamos criando um comando SQL para ser executado no banco de dados, quero imprimir o que esta la dentro do banco
//                     string query = "Select * from public.usuario";

//                     using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
//                     { // NpgsqlCommand representa um comando SQL que será executado no banco de dados
//                         using (NpgsqlDataReader dr = cmd.ExecuteReader())
//                         { // NpgsqlDataReader representa um litor de dados que irá ler os dados do banco de dados
//                         System.Console.WriteLine("Tabelas do banco de dados:");
//                         while (dr.Read()) // enquanto tiver dados para serem lidos
//                         {
//                             //System.Console.WriteLine(dr.GetString(0)); // imprime o nome da tabela, ou valor da coluna 0
//                             // System.Console.WriteLine($"Id: {dr["id"]} Nome: {dr["nome"]} Email: {dr["email"]}");
//                             System.Console.WriteLine($"Id: {dr.GetInt32(0)} Nome: {dr.GetString(1)} Email: {dr.GetString(2)}");
//                         }
//                         }
//                     }


//                     // comando delete
//                     string deletequery = "DELETE FROM public.usuario WHERE id = 2;";
//                     using (NpgsqlCommand cmd = new NpgsqlCommand(deletequery, con))
//                     {
//                         cmd.ExecuteNonQuery();
//                         System.Console.WriteLine("Registro deletado com sucesso");
//                     }

//                     // comando update
//                     string updatequery = "update public.usuario set nome = 'Maria' where id = 8";
//                     using (NpgsqlCommand cmd = new NpgsqlCommand(updatequery,con))
//                     {
//                         cmd.ExecuteNonQuery();
//                         System.Console.WriteLine("Registro atualizado com sucesso!");
//                     }

//                 }
//                 catch (NpgsqlException ex)
//                 {
//                     System.Console.WriteLine($"Erro: {ex.Message}");
//                 }
//             }

//         }
//     }

// }