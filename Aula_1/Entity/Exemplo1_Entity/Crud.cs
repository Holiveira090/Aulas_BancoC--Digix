using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo1_Entity
{
    public class Crud
    {
        public void InserirUsuario(int id, string nome, string email)
        {
            using (var db = new Ligacao())
            {
                db.Usuarios.Add(new Usuario { Id = id, Nome = nome, Email = email });
                db.SaveChanges();
            }
        }

        public void ListarUsuarios()
        {
            using (var db = new Ligacao())
            {
                var Usuarios = db.Usuarios.ToList(); // aqui é pegado todos os registros da tabela usuario, que esta como lista
                foreach (var usuario in Usuarios)
                {
                    System.Console.WriteLine($"Id: {usuario.Id} Nome: {usuario.Nome} Email: {usuario.Email}");
                }
            }
        }

        public void AtualizarUsuario(int id, string novoNome)
        {
            using (var db = new Ligacao())
            {
                var usuario = db.Usuarios.Find(id); // Aqui ele pesquisa pleo id
                if (usuario != null)
                {
                    usuario.Nome = novoNome;
                    db.SaveChanges();
                    System.Console.WriteLine("Usuario atualizado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Usuario não encontrado");
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            using (var db = new Ligacao())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    System.Console.WriteLine("Usuário deletado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Usuário não encontrado");
                }
            }
        }
    }
}