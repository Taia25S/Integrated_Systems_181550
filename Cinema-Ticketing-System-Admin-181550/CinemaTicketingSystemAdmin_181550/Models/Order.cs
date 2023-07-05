using CinemaTicketingSystemAdmin_181550.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketingSystemAdmin_181550.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public CinemaApplicationUser OrderedBy { get; set; }

        public List<TicketsInOrder> TicketsInOrder { get; set; }
    }
}
