using CinemaApp.Domain.Identity;
using CinemaApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApp.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<CinemaApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<CinemaApplicationUser>();
        }
        public void Delete(CinemaApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();

        }

        public CinemaApplicationUser Get(string id)
        {
            var user = entities.Include(z=>z.UserShoppingCart).
                Include("UserShoppingCart.TicketsInShoppingCart").
                Include("UserShoppingCart.TicketsInShoppingCart.Ticket").
                SingleOrDefault(x=>x.Id == id);
            if(user == null)
            {
                throw new ArgumentNullException("user");
            }
            return user;
        }

        public IEnumerable<CinemaApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(CinemaApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(CinemaApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
