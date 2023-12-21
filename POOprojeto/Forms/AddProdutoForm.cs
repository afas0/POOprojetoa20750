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
    public partial class AddProdutoForm : Form
    {
        private readonly Classes.Produto produto;
        public AddProdutoForm()
        {
            InitializeComponent();
            DatabaseConnection connection = new DatabaseConnection();
            produto = new Classes.Produto(connection); //para funcionar no try em baixo
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string descricao = richTextBox1.Text;

            try
            {
                produto.AddProduto(nome, descricao);
                MessageBox.Show("Produto added successfully.");
            }
            catch
            {
                MessageBox.Show("Failed to add produto. Please try again.");
            }
        }
    }
}
