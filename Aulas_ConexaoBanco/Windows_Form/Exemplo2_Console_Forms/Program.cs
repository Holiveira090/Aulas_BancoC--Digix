// using System;

// namespace Exemplo2_Console_Forms
// {
//     class Program
//     {
//         [STAThread] // STAThread é um atributo que indica que o método Main é um método de Thread de nível de aplicativo que é executado em um único Thread de aplicativo.
//         static void Main(string[] args)
//         {
//             // Aplication é a classe que gerencia a execução de um aplicativo windows forms
//             Application.EnableVisualStyles(); // Habilita o estilo visual do windows Forms
//             Application.SetCompatibleTextRenderingDefault(false); // Define o valor padr]ao para a propriedade TextRenderingDefault de todos os controles do aplicativo, ele faz com que o texto seja renderizado de forma mais nítida
//             // Application.Run(new MeuFormulario()); // Executa o aplicativo windows forms com o formulário Form1
//             Application.Run(new Calculadora());
//         }
//     }
//     // public class MeuFormulario: Form
//     // {
//     //     public MeuFormulario()
//     //     {
//     //         this.Text = "Meu Formulario";
//     //         this.Size = new Size(300, 300);

//     //         Label label = new Label();
//     //         label.Text = "Olá Mundo!";
//     //         label.Location = new Point(100, 100);
//     //         this.AutoSize = true;

//     //         this.Controls.Add(label);
//     //     }
//     // }
//     public class Calculadora : Form
//     {
//         private System.ComponentModel.IContainer components = null;
//         private System.Windows.Forms.Label Label1;
//         private System.Windows.Forms.TextBox textBox1;
//         private System.Windows.Forms.TextBox textBox2;
//         private System.Windows.Forms.Button button1;

//         public Calculadora()
//         {
//             this.components = new System.ComponentModel.Container();
//             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//             this.ClientSize = new System.Drawing.Size(800, 450);
//             this.Text = "Calculadora";

//             // Instanciar os componentes
//             this.Label1 = new System.Windows.Forms.Label();
//             this.textBox1 = new System.Windows.Forms.TextBox();
//             this.textBox2 = new System.Windows.Forms.TextBox();
//             this.button1 = new System.Windows.Forms.Button();

//             // Configurando o label
//             this.Label1.AutoSize = true;
//             this.Label1.Location = new System.Drawing.Point(30, 30);
//             this.Label1.Name = "Label1";
//             this.Label1.Size = new System.Drawing.Size(90, 20);
//             this.Label1.Text = "Digite os números";

//             // Configurando o TextBox1
//             this.textBox1.Location = new System.Drawing.Point(30, 60);
//             this.textBox1.Name = "TextBox1";
//             this.textBox1.Size = new System.Drawing.Size(200, 27);

//             this.textBox2.Location = new System.Drawing.Point(30, 90);
//             this.textBox2.Name = "TextBox2";
//             this.textBox2.Size = new System.Drawing.Size(200, 27);

//             // configurando o Button1
//             this.button1.Location = new System.Drawing.Point(30, 120);
//             this.button1.Name = "button1";
//             this.button1.Size = new System.Drawing.Size(100, 30);
//             this.button1.Text = "Calcular";
//             this.button1.Click += new System.EventHandler(this.button1_Click);

//             // Adicionando os componentes o formulario
//             this.Controls.Add(this.Label1);
//             this.Controls.Add(this.textBox1);
//             this.Controls.Add(this.textBox2);
//             this.Controls.Add(this.button1);
//         }

//         private void button1_Click(object sender, EventArgs e)
//         {
//             int num1 = 0;
//             int num2 = 0;

//             try
//             {
//                 num1 = Convert.ToInt32(textBox1.Text);
//                 num2 = Convert.ToInt32(textBox2.Text);

//                 MessageBox.Show($"A soma dos números é: {num1 + num2}\nA subtração dos números é: {num1 - num2}\nmultiplicação dos números é: {num1 * num2}\nA divisão dos números é: {num1 / num2}");
//             }
//             catch (System.Exception)
//             {
//                 MessageBox.Show("Digite apenas números inteiros");
//                 return;
//             }
//         }
//     }
// }
