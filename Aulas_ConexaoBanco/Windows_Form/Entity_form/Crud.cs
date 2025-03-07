using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_form
{
    public class Crud
    {
        // Crud Usuarios
        public void InserirUsuario(int id, string senha, string nome, int ramal, string especialidade)
        {
            using (var db = new Ligacao())
            {
                db.Usuarios.Add(new Usuario { Id_usuario = id, Password = senha, Nome_usuario = nome, Ramal = ramal, Especialidade = especialidade });
                db.SaveChanges();
            }
        }

        public void ListarUsuarios()
        {
            using (var db = new Ligacao())
            {
                var Usuarios = db.Usuarios.ToList();
                foreach (var usuario in Usuarios)
                {
                    System.Console.WriteLine($"Id: {usuario.Id_usuario} Senha: {usuario.Password} Nome: {usuario.Nome_usuario} Ramal {usuario.Ramal} Especialidade {usuario.Especialidade}");
                }
            }
        }

        public void AtualizarUsuario(int id, string novoNome)
        {
            using (var db = new Ligacao())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    usuario.Nome_usuario = novoNome;
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
        // --------------------------------------------------------------------------

        // Crud maquina
        public void InserirMaquina(int id, string tipo, int velocidade, int harddisk, int placa_rede, int memoria_ram, int fk_usuario)
        {
            using (var db = new Ligacao())
            {
                db.Maquina.Add(new Maquina { Id_maquina = id, Tipo = tipo, Velocidade = velocidade, Harddisk = harddisk, Placa_rede = placa_rede, Memoria_ram = memoria_ram, Fk_usuario = fk_usuario });
                db.SaveChanges();
            }
        }

        public void ListarMaquinas()
        {
            using (var db = new Ligacao())
            {
                var Maquina = db.Maquina.ToList();
                foreach (var maquinas in Maquina)
                {
                    System.Console.WriteLine($"Id: {maquinas.Id_maquina} tipo: {maquinas.Tipo} velocidade: {maquinas.Velocidade} Harddisk: {maquinas.Harddisk} Placa de rede: {maquinas.Placa_rede} Memoria ram: {maquinas.Memoria_ram} Usuario: {maquinas.Fk_usuario}");
                }
            }
        }

        public void AtualizarMaquina(int id, string tipo)
        {
            using (var db = new Ligacao())
            {
                var maquina = db.Maquina.Find(id);
                if (maquina != null)
                {
                    maquina.Tipo = tipo;
                    db.SaveChanges();
                    System.Console.WriteLine("Tipo de maquina atualizada com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Maquina não encontrada");
                }
            }
        }

        public void DeletarMaquina(int id)
        {
            using (var db = new Ligacao())
            {
                var maquina = db.Maquina.Find(id);
                if (maquina != null)
                {
                    db.Maquina.Remove(maquina);
                    db.SaveChanges();
                    System.Console.WriteLine("Maquina deletada com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Maquina não encontrada");
                }
            }
        }
        // --------------------------------------------------------------------------

        // Crud software
        public void InserirSoftware(int id, string produto, int harddisk, int memoria_ram, int fk_maquina)
        {
            using (var db = new Ligacao())
            {
                db.Software.Add(new Software { Id_software = id, Produto = produto, Harddisk = harddisk, Memoria_ram = memoria_ram, Fk_maquina = fk_maquina });
                db.SaveChanges();
            }
        }

        public void ListarSoftwares()
        {
            using (var db = new Ligacao())
            {
                var Software = db.Software.ToList();
                foreach (var softwares in Software)
                {
                    System.Console.WriteLine($"Id: {softwares.Id_software} Produto: {softwares.Produto} Harddisk {softwares.Harddisk} Memoria_ram: {softwares.Memoria_ram} Maquina {softwares.Fk_maquina}");
                }
            }
        }

        public void AtualizarSoftware(int id, string produto)
        {
            using (var db = new Ligacao())
            {
                var software = db.Software.Find(id);
                if (software != null)
                {
                    software.Produto = produto;
                    db.SaveChanges();
                    System.Console.WriteLine("Produto do software atualizado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Software não encontrado");
                }
            }
        }

        public void DeletarSoftware(int id)
        {
            using (var db = new Ligacao())
            {
                var software = db.Software.Find(id);
                if (software != null)
                {
                    db.Software.Remove(software);
                    db.SaveChanges();
                    System.Console.WriteLine("Software deletado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Software não encontrado");
                }
            }
        }
    }
}