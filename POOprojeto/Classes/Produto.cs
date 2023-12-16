using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOprojeto.Classes
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //construtor
        public Produto(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;

        }

        private readonly DatabaseConnection dbConnection;

        public Produto(DatabaseConnection connection)
        {
            dbConnection = connection;
        }
        public void AddProduto(string nome, string descricao)
        {
            if (!dbConnection.AddNewProdutoToDb(nome, descricao))
            {
                throw new Exception("Failed to add produto to the database.");
            };
        }
    }
}
