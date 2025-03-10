using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_form
{
    public class Crud
    {
        // Crud Usuarios
        public void InserirUsuario(int id, string nome, string senha, int ramal, string especialidade)
        {
            using (var db = new Ligacao())
            {
                db.Usuarios.Add(new Usuario { Id_usuario = id, Password = senha, Nome_usuario = nome, Ramal = ramal, Especialidade = especialidade });
                db.SaveChanges();
            }
        }

        public List<string> ListarUsuarios()
        {
            List<string> listaUsuarios = new List<string>();

            using (var db = new Ligacao())
            {
                var usuarios = db.Usuarios.ToList();
                foreach (var usuario in usuarios)
                {
                    listaUsuarios.Add($"Id: {usuario.Id_usuario} Senha: {usuario.Password} Nome: {usuario.Nome_usuario} Ramal: {usuario.Ramal} Especialidade: {usuario.Especialidade}");
                }
            }

            return listaUsuarios;
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

        public List<string> ListarMaquinas()
        {
            List<string> listaMaquinas = new List<string>();

            using (var db = new Ligacao())
            {
                var maquinas = db.Maquina.ToList();
                foreach (var maquina in maquinas)
                {
                    listaMaquinas.Add($"Id: {maquina.Id_maquina} Tipo: {maquina.Tipo} Velocidade: {maquina.Velocidade} Harddisk: {maquina.Harddisk} Placa de rede: {maquina.Placa_rede} Memória RAM: {maquina.Memoria_ram} Usuário: {maquina.Fk_usuario}");
                }
            }

            return listaMaquinas;
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

        public List<string> ListarSoftwares()
        {
            List<string> listaSoftwares = new List<string>();

            using (var db = new Ligacao())
            {
                var softwares = db.Software.ToList();
                foreach (var software in softwares)
                {
                    listaSoftwares.Add($"Id: {software.Id_software} Produto: {software.Produto} Harddisk: {software.Harddisk} Memória RAM: {software.Memoria_ram} Máquina: {software.Fk_maquina}");
                }
            }

            return listaSoftwares;
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