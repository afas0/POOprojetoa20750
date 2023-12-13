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
        public AtribuirTicketForm()
        {
            InitializeComponent();
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<Ticket> listaTickets = dbConnection.RetrieveTickets();
            foreach (Ticket item in listaTickets)
            {
                if (item.Operador == null)
                {
                    comboBox1.Items.Add(item.TicketId);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
