using CinemaApp.Domain.Domain_Models;
using CinemaApp.Domain.DTO;
using CinemaApp.Repository;
using CinemaApp.Service.Interface;
using CinemaApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaApp.Web.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCardController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public IActionResult Index()
        {
            var model = _shoppingCartService.getShoppingCartInfo(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }
        public IActionResult DeleteFromShoppingCart(int id)
        {
            _shoppingCartService.deleteTicketFromShoppingCart(User.FindFirstValue(ClaimTypes.NameIdentifier), id);

            return RedirectToAction("Index");
        }

        private Boolean OrderNow()
        {
            var result = _shoppingCartService.orderNow(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
           return result;  
        }
        public IActionResult PayOrder(string stripeEmail, string stripeToken)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = this._shoppingCartService.getShoppingCartInfo(userId);

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (Convert.ToInt32(order.TotalPrice) * 100),
                Description = "Cinema Application Payment",
                Currency = "mkd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded")
            {
                var result = this.OrderNow();

                if (result)
                {
                    return RedirectToAction("Index", "ShoppingCard");
                }
                else
                {
                    return RedirectToAction("Index", "ShoppingCard");
                }
            }

            return RedirectToAction("Index", "ShoppingCard");
        }
    }
}
