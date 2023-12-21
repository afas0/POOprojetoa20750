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
        readonly Classes.ReadFromDb connection = new Classes.ReadFromDb();

        public NovoOperadorForm()
        {
            InitializeComponent();
            operador = new Operador(connection); //para funcionar no try em baixo
            List<Operador> listaOperadores = connection.RetrieveOperadores();
            foreach (Operador item in listaOperadores)
            {
                comboBox1.Items.Add(item.Nome);
            }            


        }

            
        private void button1_Click(object sender, EventArgs e)
        {
            
            string nome = textBox1.Text;
            string especialidade = textBox2.Text;

            try
            {
                operador.AddOperardor(nome, especialidade);
                MessageBox.Show("Operador added successfully.");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch
            {
                MessageBox.Show("Failed to add operador. Please try again.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string nome = comboBox1.Text;
            string especialidade = textBox3.Text;
            int id = 0;
            List<Operador> listaOperadores = connection.RetrieveOperadores();
            foreach (Operador item in listaOperadores)
            {
                if (nome == item.Nome)
                {
                    id = item.Id;
                    break;
                }                          
            }

            try
            {
                operador.AlterarEspecialidade(especialidade, id);
                MessageBox.Show("Alterado successfully.");
                textBox3.Clear();
            }
            catch
            {
                MessageBox.Show("Failed to add alterar. Please try again.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nome = comboBox1.Text;
            List<Operador> listaOperadores = connection.RetrieveOperadores();
            foreach (Operador item in listaOperadores)
            {
                Console.WriteLine(item.Nome);
                Console.WriteLine(item.Especialidade);
                if (nome == item.Nome)
                {
                    textBox4.Text = item.Especialidade;
                    break;
                }
            }
        }
    }
}
