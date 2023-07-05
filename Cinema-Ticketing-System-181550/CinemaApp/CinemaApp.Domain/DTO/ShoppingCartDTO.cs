using CinemaApp.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public List<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
        public int TotalPrice { get; set; }
    }
}
