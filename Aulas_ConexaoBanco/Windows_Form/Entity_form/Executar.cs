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

            Maquina.Controls.Add(new Tela2 { TopLevel = false, Dock = DockStyle.Fill });
            Maquina.Controls[0].Show();

            Software.Controls.Add(new Tela3 { TopLevel = false, Dock = DockStyle.Fill });
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

            // btnInserir.Click += new EventHandler(ButtonInserir_Click);
            // btnListar.Click += new EventHandler(ButtonListar_Click);
            // btnAtualizar.Click += new EventHandler(ButtonAtualizar_Click);
            // btnDeletar.Click += new EventHandler(ButtonDeletar_click);

            lstUsuarios = new ListBox
            {
                Location = new Point(20, 300),
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
    }

    public class Tela2 : Form
    {
        public Tela2()
        {
            this.FormBorderStyle = FormBorderStyle.None; // Remove a borda da janela
            this.Text = "Tela 2";
            this.BackColor = Color.LightGreen;

            Label label = new Label
            {
                Text = "Tela 2",
                Location = new Point(100, 100),
                AutoSize = true
            };

            this.Controls.Add(label);
        }
    }

    public class Tela3 : Form
    {
        public Tela3()
        {
            this.FormBorderStyle = FormBorderStyle.None; // Remove a borda da janela
            this.Text = "Tela 3";
            this.BackColor = Color.LightCoral;

            Label label = new Label
            {
                Text = "Tela 3",
                Location = new Point(100, 100),
                AutoSize = true
            };

            this.Controls.Add(label);
        }
    }

}