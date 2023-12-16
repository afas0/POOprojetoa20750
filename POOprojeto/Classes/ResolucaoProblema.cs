using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOprojeto.Classes
{
    public class ResolucaoProblema
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string FilePath { get; set; }

        //construtor
        public ResolucaoProblema(int id, string titulo, string descricao, string filepath)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            FilePath = filepath;

        }

        private readonly DatabaseConnection dbConnection;

        public ResolucaoProblema(DatabaseConnection connection)
        {
            dbConnection = connection;
        }
        public void AddResolucaoProblema(string titulo, string descricao, string filepath)
        {
            if (!dbConnection.AddNewResolucaoProblemaToDb(titulo, descricao, filepath))
            {
                throw new Exception("Failed to add resolucao de problema to the database.");
            };
        }
    }
}
