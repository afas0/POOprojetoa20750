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
        private readonly Classes.Produto produto;
        DatabaseConnection connection = new DatabaseConnection();
        public AddResolucaoProblemaForm()
        {
            InitializeComponent();

            resolucaoProduto = new Classes.ResolucaoProblema(connection); //para funcionar no try em baixo
            produto = new Classes.Produto(connection); // é preciso para dar no operador em baixo no try
            List<Classes.Produto> listaProdutos = connection.RetrieveProdutos();
            foreach (Classes.Produto item in listaProdutos)
            {
                    comboBox1.Items.Add(item.Nome);
            }
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
                button1.BackColor = Color.Red;
                // You can use the 'selectedFileName' to work with the selected file in your application.
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text;
            string descricao = richTextBox1.Text;
            string produto = comboBox1.Text;
            int produtoid = 0;


            if (selectedFileName != null)
            {
                try
                {

                    List<Classes.Produto> listaProdutos = connection.RetrieveProdutos();
                    foreach (Classes.Produto item in listaProdutos)
                    {
                        if (item.Nome == produto)
                        {
                            produtoid = item.Id;
                        }

                    }
                    resolucaoProduto.AddResolucaoProblema(titulo, descricao, selectedFileName, produtoid);
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
