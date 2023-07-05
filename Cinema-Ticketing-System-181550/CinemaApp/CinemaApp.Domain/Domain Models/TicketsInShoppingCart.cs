using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Domain_Models
{
    public class TicketsInShoppingCart : BaseEntity
    {
        [ForeignKey("TicketId")]
        public int TicketId { get; set; }
        [ForeignKey("CardId")]
        public int CardId { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
