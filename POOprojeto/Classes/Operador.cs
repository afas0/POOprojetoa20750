﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOprojeto
{
    public class Operador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }

        private readonly DatabaseConnection dbConnection;

        public Operador()
        {
            
        }
        public Operador(DatabaseConnection connection)
        {
            dbConnection = connection;
        }
        public void AddOperardor(string nome, string especialidade)
        {
            if(!dbConnection.AddNewOperadorToDb(nome, especialidade))
            {
                throw new Exception("Failed to add ticket to the database.");
            }
        }        
    }
}
