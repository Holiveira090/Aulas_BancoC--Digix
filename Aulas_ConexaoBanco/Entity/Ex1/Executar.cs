using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Ex1
{
    public class Executar
    {
        static void Main(string[] args)
        {
            Crud crud = new Crud();

            crud.InserirUsuario(1, "teste", "joão", 1, "técnico");
            crud.ListarUsuarios();
            // System.Console.WriteLine("-----------------------------");
            // crud.AtualizarUsuario(1, "maria");
            // crud.ListarUsuarios();
            // System.Console.WriteLine("-----------------------------");
            // crud.DeletarUsuario(1);
            // crud.ListarUsuarios();
        }

        

        
    }
}