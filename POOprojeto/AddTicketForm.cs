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
    public partial class AddTicketForm : Form
    {
        private NovoClienteForm novoClienteForm;   //para o addTicketForm assumir valores
        public AddTicketForm()
        {

            // Create an instance of DatabaseConnection
            DatabaseConnection dbConnection = new DatabaseConnection();

            // Call the RetrieveClientes method to retrieve the list of Clientes
            List<string> listaNomesClientes = dbConnection.RetrieveClients();
            foreach (var item in listaNomesClientes)
            {
                Console.WriteLine(item);  //depois apagar este for each era so pa testarr
            }
            InitializeComponent();
            comboBox2.DataSource = listaNomesClientes;
        }

        private void buttonAddCliente_Click(object sender, EventArgs e)
        {
            if (novoClienteForm == null || novoClienteForm.IsDisposed)
            {
                novoClienteForm = new NovoClienteForm();
                novoClienteForm.Show();
            }
            else
            {
                novoClienteForm.Focus();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // do nothing yet
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // do nothing yet
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // do nothing yet
        }

        private void AddTicketForm_Load(object sender, EventArgs e)
        {

        }
    }
}
