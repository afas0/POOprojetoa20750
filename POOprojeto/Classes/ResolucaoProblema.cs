using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOprojeto.Classes
{
    public class ResolucaoProblema : Produto
    {
        public int IdProblema { get; set; }
        public string Titulo { get; set; }
        public string DescricaoProblema { get; set; }
        public string FilePath { get; set; }

        //construtor
        public ResolucaoProblema(int id, string titulo, string descricao, string filepath)
        {
            IdProblema = id;
            Titulo = titulo;
            DescricaoProblema = descricao;
            FilePath = filepath;

        }

        private readonly DatabaseConnection dbConnection;

        public ResolucaoProblema(DatabaseConnection connection)
        {
            dbConnection = connection;
        }

        public ResolucaoProblema()
        {
        }

        public void AddResolucaoProblema(string titulo, string descricao, string filepath, int produtoid)
        {
            if (!dbConnection.AddNewResolucaoProblemaToDb(titulo, descricao, filepath, produtoid))
            {
                throw new Exception("Failed to add resolucao de problema to the database.");
            };
        }
    }
}
