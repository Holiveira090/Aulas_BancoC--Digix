using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Entity_form
{
    public class Executar
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class MainForm : Form
    {
        private TabControl tabControl;
        private TabPage Usuario;
        private TabPage Maquina;
        private TabPage Software;

        public MainForm()
        {
            this.Text = "Sistema Multi-Tela";
            this.Size = new Size(1000, 1000);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Criando o controle de abas
            tabControl = new TabControl { Dock = DockStyle.Fill };

            // Criando as abas e adicionando as telas
            Usuario = new TabPage("Usuario") { BackColor = Color.LightBlue };
            Maquina = new TabPage("Maquina") { BackColor = Color.LightGreen };
            Software = new TabPage("Software") { BackColor = Color.LightCoral };

            // Adicionando telas dentro das abas
            Usuario.Controls.Add(new Usuarios { TopLevel = false, Dock = DockStyle.Fill });
            Usuario.Controls[0].Show();

            Maquina.Controls.Add(new maquina { TopLevel = false, Dock = DockStyle.Fill });
            Maquina.Controls[0].Show();

            Software.Controls.Add(new software { TopLevel = false, Dock = DockStyle.Fill });
            Software.Controls[0].Show();

            // Adicionando as abas ao controle de abas
            tabControl.TabPages.Add(Usuario);
            tabControl.TabPages.Add(Maquina);
            tabControl.TabPages.Add(Software);

            // Adicionando o controle de abas ao formulário principal
            this.Controls.Add(tabControl);
        }
    }
    public class Usuarios : Form
    {
        private Crud crud;
        private Label label1, label2, label3, label4, label5;
        private TextBox textBox1, textBox2, textBox3, textBox4, textBox5;
        private Button btn1, btn2, btn3, btn4;
        private ListBox lstUsuarios;
        public Usuarios()
        {
            this.FormBorderStyle = FormBorderStyle.None; // Remove a borda da janela
            this.Text = "Tela 1";
            this.BackColor = Color.LightBlue;
            this.Size = new Size(800, 500); 

            crud = new Crud();


            Font fontePadrao = new Font("Arial", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte
            Font fonteAlternativa = new Font("Italic", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte

            label1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fontePadrao, ForeColor = Color.Black };
            label2 = new Label { Text = "Nome:", Location = new Point(20, 62), Font = fontePadrao, ForeColor = Color.Black };
            label3 = new Label { Text = "Senha:", Location = new Point(20, 112), Font = fontePadrao, ForeColor = Color.Black };
            label4 = new Label { Text = "Ramal:", Location = new Point(20, 162), Font = fontePadrao, ForeColor = Color.Black };
            label5 = new Label { Text = "Especialidade:", Location = new Point(20, 212), Font = fontePadrao, ForeColor = Color.Black };
            this.Controls.Add(label1);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label4);
            this.Controls.Add(label5);

            textBox1 = new TextBox { Location = new Point(20, 35), Width = 220, Font = fonteAlternativa };
            textBox2 = new TextBox { Location = new Point(20, 85), Width = 220, Font = fonteAlternativa };
            textBox3 = new TextBox { Location = new Point(20, 135), Width = 220, Font = fonteAlternativa };
            textBox4 = new TextBox { Location = new Point(20, 185), Width = 220, Font = fonteAlternativa };
            textBox5 = new TextBox { Location = new Point(20, 235), Width = 220, Font = fonteAlternativa };
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Controls.Add(textBox4);
            this.Controls.Add(textBox5);

            btn1 = CriarBotao("Inserir", new Point(270, 30), Color.LightGreen);
            btn2 = CriarBotao("Listar", new Point(390, 30), Color.LightYellow);
            btn3 = CriarBotao("Atualizar", new Point(510, 30), Color.LightBlue);
            btn4 = CriarBotao("Deletar", new Point(630, 30), Color.LightCoral);
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            this.Controls.Add(btn4);

            btn1.Click += new EventHandler(ButtonInserir_Click);
            btn2.Click += new EventHandler(ButtonListar_Click);
            btn3.Click += new EventHandler(ButtonAtualizar_Click);
            btn4.Click += new EventHandler(ButtonDeletar_click);

            lstUsuarios = new ListBox
            {
                Location = new Point(20, 280),
                Width = 500,
                Height = 150,
                BackColor = Color.White, // Cor de fundo
                ForeColor = Color.Blue, // ForeColor é a cor da fonte
            };
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
        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void ButtonInserir_Click(object sender, EventArgs e) // sender é o objeto quando dispara o evento
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                string nome = textBox2.Text;
                string senha = textBox3.Text;
                int ramal = int.Parse(textBox4.Text);
                string especialidade = textBox5.Text;

                crud.InserirUsuario(id, nome, senha, ramal, especialidade);
                MessageBox.Show("Usuario inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (usuarios.Count > 0)
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
                int id = int.Parse(textBox1.Text);
                string nome = textBox2.Text;

                crud.AtualizarUsuario(id, nome);
                MessageBox.Show("Usuario atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int id = int.Parse(textBox1.Text);

                crud.DeletarUsuario(id);
                MessageBox.Show("Usuario deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
    }

    public class maquina : Form
    {
        private Crud crud;
        private Label label1, label2, label3, label4, label5, label6, label7;
        private TextBox textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7;
        private Button btn1, btn2, btn3, btn4;
        private ListBox lstmaquinas;
        public maquina()
        {
            this.FormBorderStyle = FormBorderStyle.None; // Remove a borda da janela
            this.Text = "Tela 2";
            this.BackColor = Color.LightGreen;

            crud = new Crud();
            Font fontePadrao = new Font("Arial", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte
            Font fonteAlternativa = new Font("Italic", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte

            label1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label2 = new Label { Text = "Tipo:", Location = new Point(20, 62), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label3 = new Label { Text = "velocidade:", Location = new Point(20, 112), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label4 = new Label { Text = "Hard Disk:", Location = new Point(20, 162), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label5 = new Label { Text = "Placa de rede:", Location = new Point(20, 212), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label6 = new Label { Text = "Memoria Ram:", Location = new Point(20, 262), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label7 = new Label { Text = "id do usuario vinculado:", Location = new Point(20, 312), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            this.Controls.Add(label1);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label4);
            this.Controls.Add(label5);
            this.Controls.Add(label6);
            this.Controls.Add(label7);

            textBox1 = new TextBox { Location = new Point(20, 35), Width = 220, Font = fonteAlternativa };
            textBox2 = new TextBox { Location = new Point(20, 85), Width = 220, Font = fonteAlternativa };
            textBox3 = new TextBox { Location = new Point(20, 135), Width = 220, Font = fonteAlternativa };
            textBox4 = new TextBox { Location = new Point(20, 185), Width = 220, Font = fonteAlternativa };
            textBox5 = new TextBox { Location = new Point(20, 235), Width = 220, Font = fonteAlternativa };
            textBox6 = new TextBox { Location = new Point(20, 285), Width = 220, Font = fonteAlternativa };
            textBox7 = new TextBox { Location = new Point(20, 335), Width = 220, Font = fonteAlternativa };
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Controls.Add(textBox4);
            this.Controls.Add(textBox5);
            this.Controls.Add(textBox6);
            this.Controls.Add(textBox7);

            btn1 = CriarBotao("Inserir", new Point(270, 30), Color.LightGreen);
            btn2 = CriarBotao("Listar", new Point(390, 30), Color.LightYellow);
            btn3 = CriarBotao("Atualizar", new Point(510, 30), Color.LightBlue);
            btn4 = CriarBotao("Deletar", new Point(630, 30), Color.LightCoral);
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            this.Controls.Add(btn4);

            btn1.Click += new EventHandler(ButtonInserir_Click);
            btn2.Click += new EventHandler(ButtonListar_Click);
            btn3.Click += new EventHandler(ButtonAtualizar_Click);
            btn4.Click += new EventHandler(ButtonDeletar_click);

            lstmaquinas = new ListBox
            {
                Location = new Point(20, 380),
                Width = 500,
                Height = 150,
                BackColor = Color.White, // Cor de fundo
                ForeColor = Color.Blue, // ForeColor é a cor da fonte
            };
            this.Controls.Add(lstmaquinas);
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
                int id = int.Parse(textBox1.Text);
                string Tipo = textBox2.Text;
                int velocidade = int.Parse(textBox3.Text);
                int harddisk = int.Parse(textBox4.Text);
                int placa_rede = int.Parse(textBox5.Text);
                int ram = int.Parse(textBox6.Text);
                int usuario = int.Parse(textBox7.Text);


                crud.InserirMaquina(id, Tipo, velocidade, harddisk, placa_rede, ram, usuario);
                MessageBox.Show("Maquina inserida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir maquina: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void ButtonListar_Click(object sender, EventArgs e)
        {
            try
            {
                lstmaquinas.Items.Clear(); // Limpar a lista

                List<string> maquina = crud.ListarMaquinas();
                if (maquina.Count > 0)
                {
                    foreach (string maquinas in maquina)
                    {
                        lstmaquinas.Items.Add(maquinas);
                    }
                }
                else
                {
                    lstmaquinas.Items.Add("Nenhuma maquina encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar maquinas: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                string tipo = textBox2.Text;

                crud.AtualizarMaquina(id, tipo);
                MessageBox.Show("Maquina atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar Maquina: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void ButtonDeletar_click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);

                crud.DeletarMaquina(id);
                MessageBox.Show("Maquina deletada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar Maquina: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }

    public class software : Form
    {
        private Crud crud;
        private Label label1, label2, label3, label4, label5, label6, label7;
        private TextBox textBox1, textBox2, textBox3, textBox4, textBox5;
        private Button btn1, btn2, btn3, btn4;
        private ListBox lstsoftwares;

        public software()
        {
            this.FormBorderStyle = FormBorderStyle.None; // Remove a borda da janela
            this.Text = "Tela 3";
            this.BackColor = Color.LightCoral;

            crud = new Crud();
            Font fontePadrao = new Font("Arial", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte
            Font fonteAlternativa = new Font("Italic", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte

            label1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label2 = new Label { Text = "Produto:", Location = new Point(20, 62), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label3 = new Label { Text = "Hard Disk:", Location = new Point(20, 112), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label4 = new Label { Text = "Memoria Ram:", Location = new Point(20, 162), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            label5 = new Label { Text = "Id da maquina:", Location = new Point(20, 212), Font = fontePadrao, ForeColor = Color.Black, AutoSize = true };
            this.Controls.Add(label1);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label4);
            this.Controls.Add(label5);

            textBox1 = new TextBox { Location = new Point(20, 35), Width = 220, Font = fonteAlternativa };
            textBox2 = new TextBox { Location = new Point(20, 85), Width = 220, Font = fonteAlternativa };
            textBox3 = new TextBox { Location = new Point(20, 135), Width = 220, Font = fonteAlternativa };
            textBox4 = new TextBox { Location = new Point(20, 185), Width = 220, Font = fonteAlternativa };
            textBox5 = new TextBox { Location = new Point(20, 235), Width = 220, Font = fonteAlternativa };
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Controls.Add(textBox4);
            this.Controls.Add(textBox5);

            btn1 = CriarBotao("Inserir", new Point(270, 30), Color.LightGreen);
            btn2 = CriarBotao("Listar", new Point(390, 30), Color.LightYellow);
            btn3 = CriarBotao("Atualizar", new Point(510, 30), Color.LightBlue);
            btn4 = CriarBotao("Deletar", new Point(630, 30), Color.LightCoral);
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            this.Controls.Add(btn4);

            btn1.Click += new EventHandler(ButtonInserir_Click);
            btn2.Click += new EventHandler(ButtonListar_Click);
            btn3.Click += new EventHandler(ButtonAtualizar_Click);
            btn4.Click += new EventHandler(ButtonDeletar_click);

            lstsoftwares = new ListBox
            {
                Location = new Point(20, 280),
                Width = 500,
                Height = 150,
                BackColor = Color.White, // Cor de fundo
                ForeColor = Color.Blue, // ForeColor é a cor da fonte
            };
            this.Controls.Add(lstsoftwares);
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
                int id = int.Parse(textBox1.Text);
                string produto = textBox2.Text;
                int harddisk = int.Parse(textBox3.Text);
                int ram = int.Parse(textBox4.Text);
                int fk_maquina = int.Parse(textBox5.Text);


                crud.InserirSoftware(id, produto, harddisk, ram, fk_maquina);
                MessageBox.Show("Software inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                lstsoftwares.Items.Clear(); // Limpar a lista
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir Software: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void ButtonListar_Click(object sender, EventArgs e)
        {
            try
            {
                lstsoftwares.Items.Clear(); // Limpar a lista

                List<string> software = crud.ListarSoftwares();
                if (software.Count > 0)
                {
                    foreach (string softwares in software)
                    {
                        lstsoftwares.Items.Add(softwares);
                    }
                }
                else
                {
                    lstsoftwares.Items.Add("Nenhum software encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar softwares: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                string produto = textBox2.Text;

                crud.AtualizarSoftware(id, produto);
                MessageBox.Show("software atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar Maquina: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void ButtonDeletar_click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);

                crud.DeletarSoftware(id);
                MessageBox.Show("software deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar software: " + ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }

}