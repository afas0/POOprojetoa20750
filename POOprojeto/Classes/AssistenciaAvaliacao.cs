﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOprojeto.Classes
{
    public class AssistenciaAvaliacao : Ticket
    {


        private readonly DatabaseConnection dbConnection;

        public AssistenciaAvaliacao(DatabaseConnection connection)
        {
            dbConnection = connection;
        }
        public void AddAvaliacaoTicket(int nota, int id, string estado)
        {
            if (!dbConnection.AddNewAvaliacaoTicketToDb(nota, id, estado))
            {
                throw new Exception("Failed to endticket to the database.");
            };
        }
        public AssistenciaAvaliacao()
        {
            // é necessario um constructer vazio para que na databaseconnection class a lista de retrieve tickets funciona Ticket ticket = new Ticket()
        }
    }
}
