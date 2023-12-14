using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOprojeto
{
    public partial class NovoOperadorForm : Form
    {
        private readonly Operador operador;
        public NovoOperadorForm()
        {
            InitializeComponent();
            DatabaseConnection connection = new DatabaseConnection();
            operador = new Operador(connection); //para funcionar no try em baixo

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string nome = textBox1.Text;
            string especialidade = textBox2.Text;

            try
            {
                operador.AddOperardor(nome, especialidade);
                MessageBox.Show("Operador added successfully.");
            }
            catch
            {
                MessageBox.Show("Failed to add operador. Please try again.");
            }
        }
    }
}
