using CinemaApp.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Service.Interface
{
    public interface IOrderService
    {
        List<Order> getAllOrders();
        Order getOrderDetails(BaseEntity model);
    }
}
