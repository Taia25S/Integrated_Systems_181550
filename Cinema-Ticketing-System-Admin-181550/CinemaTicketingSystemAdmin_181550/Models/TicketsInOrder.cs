using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTisketingSystemAdmin_191010.Models
{
    public class TicketsInOrder
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }

    }
}
