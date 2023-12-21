using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOprojeto.Forms
{
    public partial class EndTicketForm : Form
    {
        private readonly Classes.AssistenciaAvaliacao avaliacao;

        public EndTicketForm()
        {
            // Call the RetrieveClientes method to retrieve the list of Clientes
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<Ticket> listaTickets = dbConnection.RetrieveTickets();          
            InitializeComponent();
            foreach (Ticket item in listaTickets)
            {
                if (item.EstadoAssistencia == "Concluído e Resolvido" || item.EstadoAssistencia == "Concluído e Não Resolvido")
                {
                    //do nothing
                }
                else
                {
                    comboBox1.Items.Add(item.TicketId);
                }
            }

            avaliacao = new Classes.AssistenciaAvaliacao(dbConnection); //ver se é preciso
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nota = Convert.ToInt32(numericUpDown1.Value);
            int id = int.Parse(comboBox1.Text);
            string estado = comboBox2.Text;
            try
            {
                avaliacao.AddAvaliacaoTicket(nota, id, estado);
                MessageBox.Show("Ticket terminado successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
