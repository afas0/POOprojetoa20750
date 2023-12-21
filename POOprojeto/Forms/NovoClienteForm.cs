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
    public partial class NovoClienteForm : Form
    {
        private readonly Cliente cliente;
        public NovoClienteForm()
        {
            InitializeComponent();
            DatabaseConnection connection = new DatabaseConnection();
            cliente = new Cliente(connection); //para funcionar no try em baixo
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string clientenome = textBox1.Text;
            string clienteempresa = textBox2.Text;
            string clientecontacto = textBox3.Text;
            try 
            {
                if (!string.IsNullOrEmpty(clientenome) && !string.IsNullOrEmpty(clienteempresa) && !string.IsNullOrEmpty(clientecontacto) )
                {
                    cliente.AddCliente(clientenome, clienteempresa, clientecontacto);
                    MessageBox.Show("Client added successfully.");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("Campos em Branco. Please try again.");
                }
                
            }
            catch
            {
                MessageBox.Show("Failed to add client. Please try again.");
            }
            
        }
    }
}
