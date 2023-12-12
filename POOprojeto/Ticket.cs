using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace POOprojeto
{
    internal class Ticket
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
        public void AddTicket(string nomeCliente, string ticketDescricao, DateTime dataCriacao, string tipoAssistencia, string estadoAssistencia)
        {
            //if para caso der return falso dar exception
            if (!dbConnection.AddNewTicketToDb(nomeCliente, ticketDescricao, dataCriacao, tipoAssistencia, estadoAssistencia))
            {
                throw new Exception("Failed to add ticket to the database.");
            }
        }
    }
}
