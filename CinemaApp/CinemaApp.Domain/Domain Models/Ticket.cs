using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Domain_Models
{
    public class Ticket : BaseEntity
    {
        public enum Genre
        {
            Action,
            Comedy,
            Documentary,
            Drama,
            Fantasy,
            History,
            Horror,
            Mystery,
            Romance,
            Scifi,
            Thriller,
            Western
        }

        [Required]
        [Display(Name = "Movie name")]
        public string MovieName { get; set; }
        [Required]
        [Display(Name = "Movie image")]
        public string MovieImage { get; set; }
        [Required]
        [Display(Name = "Movie description")]
        public string MovieDescription { get; set; }
        [Required]
        [Display(Name = "Ticket price")]
        public int TicketPrice { get; set; }
        [Required]
        [Display(Name = "Movie rating")]
        public int MovieRating { get; set; }
        [Required]
        [Display(Name = "Movie start date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Movie end date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Movie genre")]
        public Genre MovieGenre { get; set; }

        public virtual ICollection<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
        public virtual ICollection<TicketsInOrder> TicketsInOrder { get; set; }
    }
}
