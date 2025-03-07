using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Instalar o pacote do NPGSQL
// dotnet add package Npgsql
using Npgsql;

namespace Exemplo3_ADO_Forms
{
    public class CRUD
    {
        string conexaoSQL = "Host=localhost;Database=BancoC#1;Username=postgres;Password=master";
        // A gente vai usar a tabela Usuario que tem as colunas id, nome e email
        public void InserirUsuario(int id, string nome, string email)
        {
            string query = "INSERT INTO Usuario (id, nome, email) VALUES (@id, @nome, @email)";

            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open(); // connectar com o banco
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<string> ListarUsuarios()
        {
            List<string> usuario = new List<string>();
            string query = "SELECT * FROM Usuario";

            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    // para ler os valores que retornam do banco de dados
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string linha = $"ID: {dr["id"]} Nome: {dr["nome"]} Email: {dr["email"]}";
                            usuario.Add(linha); // Adiciona a linha na lista
                        }
                    }
                }
            }
            return usuario;
        }

        public void AtualizarUsuario(int id, string novoNome)
        {
            string query = "UPDATE Usuario SET Nome = @Nome WHERE id = @id";
            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Nome", novoNome);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void DeletarUsuario(int id)
        {
            string query = "DELETE FROM Usuario WHERE id = @id";
            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}