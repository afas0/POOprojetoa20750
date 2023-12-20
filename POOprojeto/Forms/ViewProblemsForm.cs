using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace POOprojeto.Forms
{
    public partial class ViewProblemsForm : Form
    {

        private byte[] pdfFileData;
        public void SetPdfFileData(byte[] fileData)
        {
            pdfFileData = fileData;
        }

        public ViewProblemsForm()
        {
            InitializeComponent();
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<Classes.ResolucaoProblema> listaProblemas = dbConnection.RetrieveProblemas();
            foreach (Classes.ResolucaoProblema item in listaProblemas)
            {
                comboBox1.Items.Add(item.Titulo);
            }


        }
        private void ViewProblemsForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = comboBox1.Text;
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<Classes.ResolucaoProblema> listaProblemas = dbConnection.RetrieveProblemas();
            try
            {
                foreach (Classes.ResolucaoProblema item in listaProblemas)
                {
                    if (item.Titulo == nome)
                    {
                        richTextBox1.Text = item.DescricaoProblema;
                        byte[] pdfData = dbConnection.GetPdfFileFromDatabase(item.Id);
                        if (pdfData != null && pdfData.Length > 0)
                        {
                            try
                            {
                                string tempFilePath = Path.GetTempFileName(); // Create a temporary file

                                // Write the byte array to the temporary file
                                File.WriteAllBytes(tempFilePath, pdfData);

                                // Navigate the WebBrowser control to display the PDF file
                                webBrowser1.Navigate(tempFilePath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error displaying PDF file: " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No PDF file data available.");
                        }
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro a mostrar imagem");
            }

        }






    }
}
