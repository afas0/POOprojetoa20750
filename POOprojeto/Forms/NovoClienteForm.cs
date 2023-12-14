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
            //DatabaseConnection dbConnection = new DatabaseConnection();

            string clientenome = textBox1.Text;
            string clienteempresa = textBox2.Text;
            string clientecontacto = textBox3.Text;
            try 
            {
                cliente.AddCliente(clientenome, clienteempresa, clientecontacto);
                MessageBox.Show("Client added successfully.");
            }
            catch
            {
                MessageBox.Show("Failed to add client. Please try again.");
            }
            
        }
    }
}
