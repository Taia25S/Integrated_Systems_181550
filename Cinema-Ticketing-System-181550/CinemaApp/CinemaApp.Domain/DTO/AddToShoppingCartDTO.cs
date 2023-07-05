using CinemaApp.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.DTO
{
    public class AddToShoppingCartDTO
    {
        public Ticket SelectedTicket { get; set; }
        public int TicketId { get; set; }
        public int Quantity { get; set; }

    }
}
