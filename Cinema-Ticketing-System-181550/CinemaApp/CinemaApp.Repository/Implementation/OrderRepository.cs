using CinemaApp.Domain.Domain_Models;
using CinemaApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApp.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> getAllOrders()
        {
            return entities.Include(z => z.OrderedBy).Include(z => z.TicketsInOrder).Include("TicketsInOrder.Ticket").ToListAsync().Result;
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return entities.Include(z => z.OrderedBy).Include(z => z.TicketsInOrder).Include("TicketsInOrder.Ticket").SingleOrDefaultAsync(z=>z.Id == model.Id).Result;
        }
    }
}
