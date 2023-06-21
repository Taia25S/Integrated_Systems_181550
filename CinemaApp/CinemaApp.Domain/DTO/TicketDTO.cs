using CinemaApp.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.DTO
{
    public class TicketDTO
    {
        public List<Ticket> Tickets { get; set; }
        public DateTime Date { get; set; }
    }
}
