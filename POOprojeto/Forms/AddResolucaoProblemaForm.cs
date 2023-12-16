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
    public partial class AddResolucaoProblemaForm : Form
    {
        private readonly Classes.ResolucaoProblema resolucaoProduto;
        private string selectedFileName;
        public AddResolucaoProblemaForm()
        {
            InitializeComponent();
            DatabaseConnection connection = new DatabaseConnection();
            resolucaoProduto = new Classes.ResolucaoProblema(connection); //para funcionar no try em baixo
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Propriedades
            openFileDialog1.InitialDirectory = "C:\\"; // diretoria inicial
            openFileDialog1.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.png|MP4 Files|*.mp4|All Files|*.*"; // Filtro
            openFileDialog1.RestoreDirectory = true; // Reset directory

            // Show the dialog and capture the result
            DialogResult result = openFileDialog1.ShowDialog();

            // Check if the user selected a file
            if (result == DialogResult.OK)
            {
                // Get the selected file name and display it
                selectedFileName = openFileDialog1.FileName;
                MessageBox.Show("Selected file: " + selectedFileName);
                // You can use the 'selectedFileName' to work with the selected file in your application.
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text;
            string descricao = richTextBox1.Text;
            
            if (selectedFileName != null)
            {
                try
                {
                    resolucaoProduto.AddResolucaoProblema(titulo, descricao, selectedFileName);
                    MessageBox.Show("Resolucao de problema added successfully.");
                }
                catch
                {
                    MessageBox.Show("Failed to add Resolucao de problema. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Nenhum ficheiro selecionado. Please try again.");
            }
            
        }
    }
}
