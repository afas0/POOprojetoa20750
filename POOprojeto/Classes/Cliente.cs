using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOprojeto
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public string Contacto { get; set; }

        //construtor
        public Cliente (string nome, string empresa, string contacto, int clientetid)
        {
            Nome = nome;
            Empresa = empresa;           
            Contacto = contacto;
            ClienteId = clientetid;
        }

        private readonly DatabaseConnection dbConnection;

        public Cliente(DatabaseConnection connection)
        {
            dbConnection = connection;
        }
        public void AddCliente(string nome, string empresa, string contacto)
        {
            if (!dbConnection.AddNewClientToDb(nome, empresa, contacto)) 
            {
                throw new Exception("Failed to add ticket to the database.");
            };
        }             
    }
}
