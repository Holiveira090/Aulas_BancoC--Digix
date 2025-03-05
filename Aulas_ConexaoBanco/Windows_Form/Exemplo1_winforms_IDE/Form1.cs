using System;
using System.Windows.Forms;
using System.Drawing; // Necessário para a classe Point

namespace Exemplo1_winforms_IDE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show($"O número digitado foi: {textBox1.Text}");
            int num1 = 0;
            int num2 = 0;

            try
            {
                num1 = Convert.ToInt32(textBox1.Text);
                num2 = Convert.ToInt32(textBox2.Text);

                MessageBox.Show($"A soma dos números é: {num1 + num2}\nA subtração dos números é: {num1 - num2}\nmultiplicação dos números é: {num1 * num2}\nA divisão dos números é: {num1 / num2}");
            }
            catch(System.Exception)
            {
                MessageBox.Show("Digite apenas números inteiros");
                return;
            }
        }
    }
}
