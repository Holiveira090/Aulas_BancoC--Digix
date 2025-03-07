using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo3_ADO_Forms
{
    public class Executar
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Cadastro());
        }
    }
    public class Cadastro : Form
    {
        private Label label1, label2, label3; // Declaração das variaveis label
        private TextBox txtId, txtNome, txtEmail; // Declaração das variaveis TextBox
        private Button btnInserir, btnListar, btnAtualizar, btnDeletar;// Declaração das variaveis Button
        private ListBox lstUsuarios;
        private CRUD crud;

        public Cadastro() // Construtor
        {
            // Inicializar o objeto crud
            crud = new CRUD();
            // Definir o tamanho da janela e cor de fundo
            this.Size = new Size(500, 500);
            this.BackColor = Color.White; // cor de fundo

            // Fonte padrão para os textos
            Font fontePadrao = new Font("Arial", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte
            Font fonteAlternativa = new Font("Italic", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte

            // Criando as labels
            label1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fontePadrao, ForeColor = Color.Blue };
            label2 = new Label { Text = "Nome:", Location = new Point(20, 60), Font = fontePadrao, ForeColor = Color.Blue };
            label3 = new Label { Text = "Email:", Location = new Point(20, 110), Font = fontePadrao, ForeColor = Color.Blue };

            // Criando os TextBox
            txtId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonteAlternativa };
            txtNome = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonteAlternativa };
            txtEmail = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonteAlternativa };

            // Criando os botões
            btnInserir = CriarBotao("Inserir", new Point(270, 30), Color.LightGreen);
            btnListar = CriarBotao("Listar", new Point(390, 30), Color.LightYellow);
            btnAtualizar = CriarBotao("Atualizar", new Point(510, 30), Color.LightBlue);
            btnDeletar = CriarBotao("Deletar", new Point(630, 30), Color.LightCoral);

            // Criando eventos dos botões
            btnInserir.Click += new EventHandler(ButtonInserir_Click);
            btnListar.Click += new EventHandler(ButtonListar_Click);
            btnAtualizar.Click += new EventHandler(ButtonAtualizar_Click);
            btnDeletar.Click += new EventHandler(ButtonDeletar_click);

            // Criando a ListBox
            lstUsuarios = new ListBox
            {
                Location = new Point(20, 180),
                Width = 500,
                Height = 150,
                BackColor = Color.White, // Cor de fundo
                ForeColor = Color.Blue, // ForeColor é a cor da fonte
            };

            // Adicionando os controles na janela
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(txtId);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnInserir);
            this.Controls.Add(btnListar);
            this.Controls.Add(btnAtualizar);
            this.Controls.Add(btnDeletar);
            this.Controls.Add(lstUsuarios);
        }
        private Button CriarBotao(string texto, Point localizacao, Color cor)
        {
            return new Button
            {
                Text = texto,
                Location = localizacao,
                Width = 100,
                Height = 30,
                BackColor = cor,
                Font = new Font("Arial", 12, FontStyle.Bold),
            };
        }
        private void ButtonInserir_Click(object sender, EventArgs e) // sender é o objeto quando dispara o evento
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                crud.InserirUsuario(id, nome, email);
                MessageBox.Show("Usuario inserido com sucesso!", "Sucesso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir usuário: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }

        private void ButtonListar_Click(object sender, EventArgs e)
        {
            try
            {
                lstUsuarios.Items.Clear(); // Limpar a lista

                List<string> usuarios = crud.ListarUsuarios();
                if(usuarios.Count > 0)
                {
                    foreach (string usuario in usuarios)
                    {
                        lstUsuarios.Items.Add(usuario);
                    }
                }
                else
                {
                    lstUsuarios.Items.Add("Nenhum usuário encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }

        private void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;

                crud.AtualizarUsuario(id, nome);
                MessageBox.Show("Usuario atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void ButtonDeletar_click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                crud.DeletarUsuario(id);
                MessageBox.Show("Usuario deletado com sucesso!", "Sucesso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }

        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtEmail.Clear();
        }


    }
}
