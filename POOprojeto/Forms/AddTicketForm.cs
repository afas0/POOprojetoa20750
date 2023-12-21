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
        private readonly Ticket ticket;

        
        public AddTicketForm()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            InitializeComponent();
            populatestuff();           
            ticket = new Ticket(dbConnection);
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
            string ticketNome = comboBox2.Text;
            string ticketDescricao= richTextBox1.Text;
            DateTime ticketData = DateTime.Now;
            string ticketTipo = comboBox3.Text;
            string ticketEstado = "Aberto";
            try
            {
                ticket.AddTicket(ticketNome, ticketDescricao, ticketData, ticketTipo, ticketEstado);
                MessageBox.Show("Ticket added successfully.");
                richTextBox1.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populatestuff();
        }
        private void populatestuff()
        {
            Classes.ReadFromDb dbConnection = new Classes.ReadFromDb();
            List<string> listaNomesClientes = dbConnection.RetrieveClients();
            comboBox2.DataSource = listaNomesClientes;
        }
    }
}
