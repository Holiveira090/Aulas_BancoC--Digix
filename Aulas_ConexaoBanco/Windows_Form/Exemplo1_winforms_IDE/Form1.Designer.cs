namespace Exemplo1_winforms_IDE;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;


    private System.Windows.Forms.Label Label1; // Criação de um atributo com o tipo de uma classe específica para texto

    private System.Windows.Forms.TextBox textBox1; // Criação de um atributo com o tipo de uma classe específica para entrada de texto

    private System.Windows.Forms.TextBox textBox2;

    private System.Windows.Forms.Button button1; // Criação de um atributo com o tipo de uma classe específica para botão

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }


    #region Windows Form Designer generated code
    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() // Esse é o metodo chamado para inicializar os componentes do formulario
    {
        this.components = new System.ComponentModel.Container(); // cria um novo container de componentes
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; // define o modo de ajuste automático do formulário
        this.ClientSize = new System.Drawing.Size(800, 450); // define o tamanho do formulário
        this.Text = "Iniciar"; // define o texto do formulario

        // Inicializar as variaveis criadas com instâncias de suas classes
        this.Label1 = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.button1 = new System.Windows.Forms.Button();

        // Configuração do label1
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(30, 30);
        this.Label1.Name = "label1";
        this.Label1.Size = new System.Drawing.Size(90, 20);
        this.Label1.Text = "Digite um número: ";

        // Configuração do textBox1
        this.textBox1.Location = new System.Drawing.Point(30, 60);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(100, 20);

        // Configuração do textBox2
        this.textBox2.Location = new System.Drawing.Point(30, 90);
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(100, 20);

        // Configuração do button1
        this.button1.Location = new System.Drawing.Point(30, 120);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(100, 20);
        this.button1.Text = "Clique aqui";
        this.button1.Click += new System.EventHandler(this.button1_Click);

        // Adicionando os componentes ao formulario
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.button1);


    }

    #endregion
}
