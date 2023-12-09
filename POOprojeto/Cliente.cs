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
        //add clientes info para a db
        //ligação a DatabaseConnection Classe
        //DatabaseConnection dbConnection = new DatabaseConnection();
        //metodo para add cliente
        //MySqlConnection connection = new MySqlConnection();

        // Now you can use 'connectionString' in this class as needed
        // For instance, you can create a MySqlConnection:
        private readonly DatabaseConnection dbConnection;

        public Cliente(DatabaseConnection connection)
        {
            dbConnection = connection;
        }
        public void AddCliente(string nome, string empresa, string contacto)
        {
            dbConnection.AddNewClientToDb(nome, empresa, contacto);
        }


    }
}
