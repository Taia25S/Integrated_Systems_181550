using CinemaApp.Domain.Domain_Models;
using CinemaApp.Repository.Interface;
using CinemaApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Service.Implementation
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> getAllOrders()
        {
            return _orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return _orderRepository.getOrderDetails(model);
        }
    }
}
