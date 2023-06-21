using CinemaApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Domain_Models
{
    public class ShoppingCart : BaseEntity
    {
        public string ApplicationUserId { get; set; }

        public virtual ICollection<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
    }
}
