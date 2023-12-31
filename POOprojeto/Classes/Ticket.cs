using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using POOprojeto.Classes;

namespace POOprojeto
{
    public class Ticket
    {
        // Properties with attributes
        public int TicketId { get; set; }

        [Required]
        public string NomeCliente { get; set; }

        [StringLength(100)]
        public string TicketDescricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public string Operador { get; set; }

        public string TipoAssistencia { get; set; }

        public string EstadoAssistencia { get; set; }

        public int? NotaAssistencia { get; set; }

        // Constructor
        public Ticket(int ticketId, string nomeCliente, string ticketDescricao, DateTime dataCriacao, string operador, string tipoAssistencia, string estadoAssistencia)
        {
            TicketId = ticketId;
            NomeCliente = nomeCliente;
            TicketDescricao = ticketDescricao;
            DataCriacao = dataCriacao;
            Operador = operador;
            TipoAssistencia = tipoAssistencia;
            EstadoAssistencia = estadoAssistencia;
        }

        private readonly DatabaseConnection dbConnection;

        public Ticket(DatabaseConnection connection)
        {
            dbConnection = connection;
        }

        public Ticket()
        {
            // é necessario um constructer vazio para que na databaseconnection class a lista de retrieve tickets funcione Ticket ticket = new Ticket()
        }

        public void AddTicket(string nomeCliente, string ticketDescricao, DateTime dataCriacao, string tipoAssistencia, string estadoAssistencia)
        {
            //if para caso der return falso dar exception
            if (!dbConnection.AddNewTicketToDb(nomeCliente, ticketDescricao, dataCriacao, tipoAssistencia, estadoAssistencia))
            {
                throw new Exception("Failed to add ticket to the database.");
            }
        }

        public void AtribuirOperador(string nome, int id, string estado)
        {
            if (!dbConnection.AtribuirOperadorToDb(nome, id, estado))
            {
                throw new Exception("Failed to add ticket to the database.");
            }
        }
    }
}
