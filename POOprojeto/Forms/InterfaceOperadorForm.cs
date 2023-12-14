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
    public partial class InterfaceOperadorForm : Form     
    {
        private AddTicketForm addTicketForm;   //para o addTicketForm assumir valores
        private AtribuirTicketForm atribuirTicket;
        private NovoOperadorForm novoOperadorForm;
        private Forms.AddProdutoForm addProdutoForm;

        public InterfaceOperadorForm()
        {           
            InitializeComponent();
            PopulateListView(); //metodo para popular a listview
        }

        private void buttonAddTicket_Click(object sender, EventArgs e)
        {
            if (addTicketForm == null || addTicketForm.IsDisposed)
            {
                addTicketForm = new AddTicketForm();                
                addTicketForm.Show();
            }
            else
            {
                addTicketForm.Focus();
            }

            
        }

        private void listViewTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nothing
        }
        //coloca itens na list liew
        private void PopulateListView()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<Ticket> listaTickets = dbConnection.RetrieveTickets();
            listViewTicket.Items.Clear(); //limpar quando der refresh
            listViewTicket.Columns.Clear();
            listViewTicket.Columns.Add("Ticket ID", 100);
            listViewTicket.Columns.Add("Nome Cliente", 100);
            listViewTicket.Columns.Add("Ticket Descricao", 100);
            listViewTicket.Columns.Add("Data Criacao", 100);
            listViewTicket.Columns.Add("Operador", 100);
            listViewTicket.Columns.Add("Tipo Assistencia", 100);
            listViewTicket.Columns.Add("Estado Assistencia", 100);

            try
            {
                foreach (Ticket item in listaTickets)
                {
                    ListViewItem listViewItem = new ListViewItem(item.TicketId.ToString());
                    listViewItem.SubItems.Add(item.NomeCliente);
                    listViewItem.SubItems.Add(item.TicketDescricao);
                    listViewItem.SubItems.Add(item.DataCriacao.ToString());
                    listViewItem.SubItems.Add(item.Operador);
                    listViewItem.SubItems.Add(item.TipoAssistencia);
                    listViewItem.SubItems.Add(item.EstadoAssistencia);
                    listViewTicket.Items.Add(listViewItem); // Add items to the ListView
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            if (atribuirTicket == null || atribuirTicket.IsDisposed)
            {
                atribuirTicket = new AtribuirTicketForm();
                atribuirTicket.Show();
            }
            else
            {
                atribuirTicket.Focus();
            }
        }

        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (novoOperadorForm == null || novoOperadorForm.IsDisposed)
            {
                novoOperadorForm = new NovoOperadorForm();
                novoOperadorForm.Show();
            }
            else
            {
                novoOperadorForm.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (addProdutoForm == null || addProdutoForm.IsDisposed)
            {
                addProdutoForm = new Forms.AddProdutoForm();
                addProdutoForm.Show();
            }
            else
            {
                addProdutoForm.Focus();
            }
        }
    }
}
