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
        public InterfaceOperadorForm()
        {
            InitializeComponent();
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
    }
}
