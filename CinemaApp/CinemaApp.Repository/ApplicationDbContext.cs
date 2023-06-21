using CinemaApp.Domain.Domain_Models;
using CinemaApp.Domain.Identity;
using CinemaApp.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Repository
{
    public class ApplicationDbContext : IdentityDbContext<CinemaApplicationUser>
    {
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TicketsInShoppingCart> TicketsInShoppingCarts { get; set; }

        public virtual DbSet<CinemaApplicationUser> CinemaApplicationUsers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<TicketsInOrder> TicketsInOrders { get; set; }

        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TicketsInShoppingCart>().HasKey(c => new { c.TicketId, c.CardId });
            builder.Entity<TicketsInOrder>().HasKey(c => new { c.TicketId, c.OrderId });
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
