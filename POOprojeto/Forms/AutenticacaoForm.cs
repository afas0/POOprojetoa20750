using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POOprojeto
{
    public partial class AutenticacaoForm : Form
    {
        public AutenticacaoForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUser.Text;
            string password = textBoxPassword.Text;
            DatabaseConnection dbConnector = new DatabaseConnection();
            if (dbConnector.CheckCredentials(username, password))
            {
                MessageBox.Show("Login successful");
                this.Hide(); // Hide the current form
                InterfaceOperadorForm form2 = new InterfaceOperadorForm();
                form2.FormClosed += (s, args) => this.Close(); // Close the current form when the secondary form is closed
                form2.Show();

            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
