using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace POOprojeto
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //DatabaseConnection dbConnector = new DatabaseConnection();
            //dbConnector.ConnectToDatabase();
            Application.Run(new AutenticacaoForm());
            //AutenticacaoForm form1 = new AutenticacaoForm();
            //form1.Show();           
        }
    }
}
