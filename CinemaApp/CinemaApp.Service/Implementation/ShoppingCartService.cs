using CinemaApp.Domain.Domain_Models;
using CinemaApp.Domain.DTO;
using CinemaApp.Repository.Interface;
using CinemaApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApp.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<TicketsInOrder> _ticketsInOrderRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<EmailMessage> _emailRepository;

        public ShoppingCartService(IUserRepository userRepository, IRepository<TicketsInOrder> ticketsInOrderRepository,
            IRepository<ShoppingCart> shoppingCartRepository, IRepository<Order> orderRepository, IRepository<EmailMessage> emailRepository)
        {
            _userRepository = userRepository;
            _ticketsInOrderRepository = ticketsInOrderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
            _emailRepository = emailRepository;
    }
        public bool deleteTicketFromShoppingCart(string userId, int ticketId)
        {
            if (!string.IsNullOrEmpty(userId) && ticketId!=null)
            {
                var loggedInUser = _userRepository.Get(userId);
                var userShoppingCard = loggedInUser.UserShoppingCart;
                var itemToDelete = userShoppingCard.TicketsInShoppingCart.Where(z=>z.TicketId == ticketId).FirstOrDefault();
                userShoppingCard.TicketsInShoppingCart.Remove(itemToDelete);
                _shoppingCartRepository.Update(userShoppingCard);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ShoppingCartDTO getShoppingCartInfo(string userId)
        {
            var user = _userRepository.Get(userId);

            var userShoppingCard = user.UserShoppingCart;

            var ticketList = userShoppingCard.TicketsInShoppingCart.Select(z => new
            {
                Quantity = z.Quantity,
                TicketPrice = z.Ticket.TicketPrice

            });

            int totalPrice = 0;

            foreach (var item in ticketList)
            {
                totalPrice += item.TicketPrice * item.Quantity;
            }

            ShoppingCartDTO model = new ShoppingCartDTO
            {
                TotalPrice = totalPrice,
                TicketsInShoppingCart = userShoppingCard.TicketsInShoppingCart.ToList()
            };
            return model;
        }

        public bool orderNow(string userId)
        {
            var user = _userRepository.Get(userId);

            var userShoppingCard = user.UserShoppingCart;

            EmailMessage message = new EmailMessage();
            message.MailTo = user.Email;
            message.Subject = "Successfully created order!";
            message.Status = false;
           

            Order newOrder = new Order
            {
                UserId = user.Id,
                OrderedBy = user
            };

            _orderRepository.Insert(newOrder);

            List<TicketsInOrder> ticketsInOrder = userShoppingCard.TicketsInShoppingCart.Select(z => new TicketsInOrder
            {
                Ticket = z.Ticket,
                TicketId = z.TicketId,
                Order = newOrder,
                OrderId = newOrder.Id,
                Quantity = z.Quantity

            }).ToList();


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Your order is completed. The order contains: ");
            var totalPrice = 0;

            for (int i = 1; i <= ticketsInOrder.Count(); i++)
            {
                var item = ticketsInOrder[i - 1];
                totalPrice += item.Quantity * item.Ticket.TicketPrice;
                sb.AppendLine(i.ToString()+ ". " + item.Ticket.MovieName+" with price of: "+item.Ticket.TicketPrice + " and quantity of: "+ item.Quantity);
            }
            sb.AppendLine("Total Price: "+totalPrice.ToString());

            message.Content = sb.ToString();

            foreach (var item in ticketsInOrder)
            {
                _ticketsInOrderRepository.Insert(item);
            }
            user.UserShoppingCart.TicketsInShoppingCart.Clear();

            this._emailRepository.Insert(message);

            _userRepository.Update(user);
            return true;
        }
    }
}
