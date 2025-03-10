using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace Exemplo3_ADO_Forms
{
    public class Executar
    {
        [STAThread] // Define que o aplicativo deve rodar em um único thread de STA (Single-Threaded Apartment)
        static void Main()
        {
            Application.EnableVisualStyles(); // Habilita estilos visuais modernos
            Application.SetCompatibleTextRenderingDefault(false); // Garante que a renderização de texto seja compatível com versões mais recentes
            Application.Run(new Cadastro()); // Inicializa a janela principal do aplicativo
        }
    }

    public class Cadastro : Form
    {
        // Declaração de componentes da interface gráfica
        private Label label1, label2, label3;
        private TextBox txtId, txtNome, txtEmail;
        private Button btnInserir, btnListar, btnAtualizar, btnDeletar;
        private ListBox lstUsuarios;
        private CRUD crud;
        // Criar uma varialvel para guardar as configurações das telas
        private TableLayoutPanel tableLayoutPanel1;

        public Cadastro() // Construtor
        {
            // Inicializar o objeto CRUD
            crud = new CRUD();

            // Definir o tamanho da janela e cor de fundo 
            this.Size = new Size(550, 500);
            this.Text = "Cadastro de Usuários";
            this.BackColor = Color.White; // Cor de fundo
            // Deixar a tela Responsiva
            this.FormBorderStyle = FormBorderStyle.Sizable; // FormBorderStyle é para definir o estilo da borda da janela
            //  Sizable é para permitir redimensionar a janela

            // Fonte padrão para os textos
            Font fontePadrao = new Font("Arial", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte
            Font fontealternativa = new Font("Italic", 12, FontStyle.Bold);

            tableLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Top, // DockStyle é para definir a posição do controle, e o top é para definir o controle no topo.
                ColumnCount = 2, // Definir o número de colunas
                RowCount = 5, // Definir o número de linhas
                AutoSize = true, // AutoSize é para definir o tamanho do controle automaticamente
                Padding = new Padding(10), // Padding é para definir o preenchimento do controle
            };

            // Dimencionando as colunas
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Definir o tamanho da coluna em porcentagem, 30F é 30%
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F)); // Definir o tamanho da coluna em porcentagem, 70F é 70%


            // Criando as labels
            // label1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fontePadrao, ForeColor = Color.Blue };
            // label2 = new Label { Text = "Nome:", Location = new Point(20, 60), Font = fontePadrao, ForeColor = Color.Blue };
            // label3 = new Label { Text = "Email:", Location = new Point(20, 110), Font = fontePadrao, ForeColor = Color.Blue };
            // Labels com novo layout
            label1 = CriarLabel("ID:");
            label2 = CriarLabel("Nome:");
            label3 = CriarLabel("Email:");


            // Criando os TextBox
            // txtId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fontealternativa };
            // txtNome = new TextBox { Location = new Point(20, 80), Width = 220, Font = fontealternativa };
            // txtEmail = new TextBox { Location = new Point(20, 130), Width = 220, Font = fontealternativa };

            // TextBox com novo layout
            txtId = CriarTextBox();
            txtNome = CriarTextBox();
            txtEmail = CriarTextBox();

            // Vamos inserir os controles no TableLayoutPanel
            tableLayoutPanel1.Controls.Add(label1, 0, 0); // Adicionando o label1 na coluna 0 e linha 0
            tableLayoutPanel1.Controls.Add(txtId, 1, 0); // Adicionando o txtId na coluna 1 e linha 0
            tableLayoutPanel1.Controls.Add(label2, 0, 1); // Adicionando o label2 na coluna 0 e linha 1
            tableLayoutPanel1.Controls.Add(txtNome, 1, 1); // Adicionando o txtNome na coluna 1 e linha 1
            tableLayoutPanel1.Controls.Add(label3, 0, 2); // Adicionando o label3 na coluna 0 e linha 2
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 2); // Adicionando o txtEmail na coluna 1 e linha 2

            // Novo layout dos botões
            FlowLayoutPanel panelBotoes = new FlowLayoutPanel
            {
                Dock = DockStyle.Top, // DockStyle é para definir a posição do controle, e o top é para definir o controle no topo.
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight, // FlowDirection é para definir a direção do controle
                Padding = new Padding(10) // Padding é para definir o preenchimento do controle
            };

            // Criando os botões
            btnInserir = CriarBotao("Inserir", "https://cdn-icons-png.flaticon.com/512/992/992651.png");
            btnListar = CriarBotao("Listar", "https://cdn-icons-png.flaticon.com/512/1087/1087080.png");
            btnAtualizar = CriarBotao("Atualizar", "https://cdn-icons-png.flaticon.com/512/3063/3063825.png");
            btnDeletar = CriarBotao("Deletar", "https://cdn-icons-png.flaticon.com/512/1214/1214428.png");

            // Vou adicionar os botões no panelBotoes
            panelBotoes.Controls.Add(btnInserir);
            panelBotoes.Controls.Add(btnListar);
            panelBotoes.Controls.Add(btnAtualizar);
            panelBotoes.Controls.Add(btnDeletar);

            // Craindo enventos dos botões
            btnInserir.Click += new EventHandler(ButtonInserir_Click);
            btnListar.Click += new EventHandler(ButtonListar_Click);
            btnAtualizar.Click += new EventHandler(ButtonAtualizar_Click);
            btnDeletar.Click += new EventHandler(ButtonDeletar_Click);

            // Criando a ListBox 
            lstUsuarios = new ListBox
            {
                Dock = DockStyle.Fill, // DockStyle é para definir a posição do controle, e o Fill é para preencher o controle
                Location = new Point(20, 200), // Localização do controle
                Width = 300, // Largura do controle
                Height = 300, // Altura do controle
                BackColor = Color.White, // Cor de fundo
                ForeColor = Color.Blue, // Cor da fonte
                // Borda do controle
                BorderStyle = BorderStyle.FixedSingle, // BorderStyle é para definir o estilo da borda do controle
            };

            // Adicionando os controles na janela
            // this.Controls.Add(label1);
            // this.Controls.Add(label2);
            // this.Controls.Add(label3);
            // this.Controls.Add(txtId);
            // this.Controls.Add(txtNome);
            // this.Controls.Add(txtEmail);
            this.Controls.Add(lstUsuarios); // Aqui sempre te que ser o primeiro porque se não ele vai ficar por cima dos outros controles
            this.Controls.Add(tableLayoutPanel1);
            this.Controls.Add(panelBotoes);

        }

        // Configuração global das labels que vou usar
        private Label CriarLabel(string texto)
        {
            return new Label
            {
                Text = texto,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                Anchor = AnchorStyles.Left // AnchorStyles é para definir a posição do  controle na janela esquerda
            };
        }

        // Configuração global dos Texbox que vou usar
        private TextBox CriarTextBox()
        {
            return new TextBox
            {
                Font = new Font("Arial", 12, FontStyle.Bold),
                Anchor = AnchorStyles.Left | AnchorStyles.Right// AnchorStyles é para definir a posição do controle na janela esquerda e direita
            };
        }

        // private Button CriarBotao(string texto, Point localizacao, Color cor)
        // {
        //     return new Button
        //     {
        //         Text = texto,
        //         Location = localizacao,
        //         Width = 100,
        //         Height = 30,
        //         BackColor = cor,
        //         ForeColor = Color.White,
        //         Font = new Font("Arial", 12, FontStyle.Bold),
        //     };
        // }

        private Button CriarBotao(string texto, string urlImagem)
        {
            Button botao = new Button
            {
                Text = texto,
                Width = 120,
                Height = 40,
                BackColor = Color.LightGreen,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextImageRelation = TextImageRelation.ImageBeforeText, // TextImageRelation é para definir a relação entre o texto e a imagem
                ImageAlign = ContentAlignment.MiddleLeft, // ImageAlign é para definir o alinhamento da imagem
                Padding = new Padding(5, 0, 5, 0) // Padding é para definir o preenchimento do controle
            };

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imagemBytes = webClient.DownloadData(urlImagem); // DownloadData é para baixar os dados da imagem
                    using (var ms = new System.IO.MemoryStream(imagemBytes))
                    {
                        botao.Image = Image.FromStream(ms); // Image é para definir a imagem do controle, FromStream é para criar uma imagem a partir de um fluxo
                        botao.Image = new Bitmap(botao.Image, new Size(30, 30)); // Bitmap é para criar uma imagem, Size é para definir o tamanho da imagem
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return botao;


        }

        private void ButtonInserir_Click(object sender, EventArgs e) // sender é objeto quando dispara o evneto
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                crud.InserirUsuario(id, nome, email);
                MessageBox.Show("Usuário inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;

                crud.AtualizarUsuario(id, nome);
                MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lstUsuarios.Items.Add(usuario);
                }
                else
                {
                    lstUsuarios.Items.Add("Nenhum usuário encontrado!");
                }


            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao listar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ButtonDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                crud.DeletarUsuario(id);
                MessageBox.Show("Usuário deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtId.Clear(); // Limpar o campo
            txtNome.Clear();
            txtEmail.Clear();
        }


    }
}