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
    public partial class AtribuirTicketForm : Form
    {
        
        
        private readonly Ticket ticket;
        public AtribuirTicketForm()
        {
            InitializeComponent();
            DatabaseConnection dbConnection = new DatabaseConnection();
            ticket = new Ticket(dbConnection); // é preciso para dar no operador em baixo no try
            List<Ticket> listaTickets = dbConnection.RetrieveTickets();
            List<Operador> listaOperadores = dbConnection.RetrieveOperadores();
            foreach (Ticket item in listaTickets)
            {
                if (item.Operador == null)
                {
                    comboBox1.Items.Add(item.TicketId);
                }
            }            
            foreach (Operador item in listaOperadores)
            {
                comboBox2.Items.Add(item.Nome);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = comboBox2.Text;
            int id = int.Parse(comboBox1.Text);
            string ticketEstado = "Em andamento";
            try
            {
                ticket.AtribuirOperador(nome, id, ticketEstado);
                MessageBox.Show("Updated successfully.");
            }
            catch
            {
                MessageBox.Show("Failed to update. Please try again.");
            }
        }
    }


}
