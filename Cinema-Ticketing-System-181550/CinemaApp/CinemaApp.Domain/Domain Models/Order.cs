using CinemaApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Domain_Models
{ 
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public CinemaApplicationUser OrderedBy { get; set; }
        public List<TicketsInOrder> TicketsInOrder { get; set; }
    }
}
