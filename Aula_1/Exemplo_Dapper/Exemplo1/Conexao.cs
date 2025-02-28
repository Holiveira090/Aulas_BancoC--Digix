using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

// Para usar o Dapper, é necessario instalar o pacote Dapper

// dotnet add package Dapper
// dotnet add package Npgsql

namespace Exemplo1
{
    public class Conexao
    {
        private static readonly string conexaoDB = "Host=localhost;Database=BancoC#1;Username=postgres;Password=master";

        public static IDbConnection GetConexao() // IDbConnection é uma interface que representa uma conexão aberta com um banco de dados
        {
            return new NpgsqlConnection(conexaoDB);
        }
    }
}