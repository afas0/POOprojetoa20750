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
        private Forms.AddResolucaoProblemaForm addResolucaoProblemaForm;
        private Forms.EndTicketForm endTicketForm;
        private Forms.ViewProblemsForm viewProblemsForm;


        public InterfaceOperadorForm()
        {           
            InitializeComponent();
            PopulateListView(); //metodo para popular a listview
        }

        private void buttonAddTicket_Click(object sender, EventArgs e)
        {
            CloseOtherForms(addTicketForm);
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
            Classes.ReadFromDb dbConnection = new Classes.ReadFromDb();
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
            listViewTicket.Columns.Add("Avaliação", 100);

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
                    listViewItem.SubItems.Add(item.NotaAssistencia.ToString());
                    listViewTicket.Items.Add(listViewItem); // Add items to the ListView
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            foreach (ColumnHeader column in listViewTicket.Columns)
            {
                column.Width = -1; // Auto-size the column width to fit the content
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
                CloseOtherForms(atribuirTicket);
                atribuirTicket = new AtribuirTicketForm();
                atribuirTicket.Show();
            }
            else
            {
                atribuirTicket.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (novoOperadorForm == null || novoOperadorForm.IsDisposed)
            {
                
                if (novoOperadorForm == null || novoOperadorForm.IsDisposed)
                {
                    CloseOtherForms(novoOperadorForm);
                    novoOperadorForm = new NovoOperadorForm();
                    novoOperadorForm.Show();
                }
                else
                {
                          
                    novoOperadorForm = new NovoOperadorForm();
                    novoOperadorForm.Show();
                }
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
                CloseOtherForms(addProdutoForm);
                addProdutoForm = new Forms.AddProdutoForm();
                addProdutoForm.Show();
            }
            else
            {
                addProdutoForm.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (addResolucaoProblemaForm == null || addResolucaoProblemaForm.IsDisposed)
            {
                CloseOtherForms(addResolucaoProblemaForm);
                addResolucaoProblemaForm = new Forms.AddResolucaoProblemaForm();
                addResolucaoProblemaForm.Show();
            }
            else
            {
                addResolucaoProblemaForm.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (endTicketForm == null || endTicketForm.IsDisposed)
            {
                CloseOtherForms(endTicketForm);
                endTicketForm = new Forms.EndTicketForm();
                endTicketForm.Show();
            }
            else
            {
                endTicketForm.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (viewProblemsForm == null || viewProblemsForm.IsDisposed)
            {
                CloseOtherForms(viewProblemsForm);
                viewProblemsForm = new Forms.ViewProblemsForm();
                viewProblemsForm.Show();
            }
            else
            {
                viewProblemsForm.Focus();
            }
            

        }
        private void CloseOtherForms(Form form)
        {

            List<Form> formsToClose = new List<Form>
            {
                viewProblemsForm, endTicketForm, addResolucaoProblemaForm,
                addProdutoForm, atribuirTicket, addTicketForm, novoOperadorForm
            };

            // Close all other forms except the main form and the new form
            foreach (Form formToClose in formsToClose)
            {
                if (formToClose != null)
                {
                    formToClose.Close();
                }
            }           
        }
    }
}
