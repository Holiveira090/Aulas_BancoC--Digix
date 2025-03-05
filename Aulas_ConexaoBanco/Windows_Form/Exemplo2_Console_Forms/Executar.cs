using System;
using System.Windows.Forms;
using System.Drawing;

namespace Exemplo2_Console_Forms
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
        private TabPage tabPage1;
        private TabPage tabPage2;

        public MainForm()
        {
            this.Text = "Sistema Multi-Tela";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Criando o controle de abas
            tabControl = new TabControl { Dock = DockStyle.Fill };

            // Criando as abas e adicionando as telas
            tabPage1 = new TabPage("Tela 1") { BackColor = Color.LightBlue };
            tabPage2 = new TabPage("Tela 2") { BackColor = Color.LightGreen };

            // Adicionando telas dentro das abas
            tabPage1.Controls.Add(new Tela1 { TopLevel = false, Dock = DockStyle.Fill });
            tabPage1.Controls[0].Show();

            tabPage2.Controls.Add(new Tela2 { TopLevel = false, Dock = DockStyle.Fill });
            tabPage2.Controls[0].Show();

            // Adicionando as abas ao controle de abas
            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);

            // Adicionando o controle de abas ao formulário principal
            this.Controls.Add(tabControl);
        }
    }

    public class Tela1 : Form
    {
        public Tela1()
        {
            this.FormBorderStyle = FormBorderStyle.None; // Remove a borda da janela
            this.Text = "Tela 1";
            this.BackColor = Color.LightBlue;

            Label label = new Label
            {
                Text = "Tela 1",
                Location = new Point(100, 100),
                AutoSize = true
            };

            this.Controls.Add(label);
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
}
