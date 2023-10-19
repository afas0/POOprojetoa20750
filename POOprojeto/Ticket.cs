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

        public string EquipaIT { get; set; }


    // Constructor
    public Ticket(int ticketId, string nomeCliente, string ticketDescricao, DateTime dataCriacao, string equipaIT)
        {
            TicketId = ticketId;
            NomeCliente = nomeCliente;
            TicketDescricao = ticketDescricao;
            DataCriacao = dataCriacao;
            EquipaIT = equipaIT;
        }
    }
}
