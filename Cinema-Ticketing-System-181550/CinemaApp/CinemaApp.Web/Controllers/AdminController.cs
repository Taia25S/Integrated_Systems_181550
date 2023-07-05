using CinemaApp.Domain.Domain_Models;
using CinemaApp.Domain.Identity;
using CinemaApp.Service.Interface;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IOrderService _orderService;
        private readonly UserManager<CinemaApplicationUser> userManager;
        private readonly ITicketService _ticketService;
        public AdminController(IOrderService orderService, UserManager<CinemaApplicationUser> _userManager,
            ITicketService ticketService)
        {
            _orderService = orderService;
            this.userManager = _userManager;
            _ticketService = ticketService;
        }
        [HttpGet("[action]")]
        public List<Order> GetAllActiveOrders()
        {
            return _orderService.getAllOrders();
        }
        [HttpPost("[action]")]
        public Order GetOrderDetails(BaseEntity model)
        {
            return _orderService.getOrderDetails(model);
        }
        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDto> model)
        {
            bool status = true;

            foreach (var user in model)
            {
                var userCheck = userManager.FindByEmailAsync(user.Email).Result;
                if (userCheck == null)
                {
                    var newUser = new CinemaApplicationUser
                    {
                        UserName = user.Email,
                        NormalizedEmail = user.Email,
                        Email = user.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserShoppingCart = new ShoppingCart()
                    };
                    var result = userManager.CreateAsync(newUser, user.Password).Result;
                    status = status && result.Succeeded;
                }
                else
                {
                    continue;
                }
            }
            return status;
        }


        [HttpPost]
        public FileContentResult ExportTicketsFromGenre([Bind("MovieGenre")] Ticket ticket)
        {
            var genre = ticket.MovieGenre;

            string fileName = "Tickets" + genre + ".xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add(genre.ToString());

                worksheet.Cell(1, 1).Value = "Ticket Id";
                worksheet.Cell(1, 2).Value = "Movie Name";
                worksheet.Cell(1, 3).Value = "Movie Price";
                worksheet.Cell(1, 4).Value = "Streaming Start Date";
                worksheet.Cell(1, 5).Value = "Streaming End Date";


                var result = this._ticketService.GetAllTickets().Where(z => z.MovieGenre == genre).ToList();

                if (result.Count > 0)
                {
                    for (int i = 1; i <= result.Count(); i++)
                    {
                        var item = result[i - 1];

                        worksheet.Cell(i + 1, 1).Value = item.Id.ToString();
                        worksheet.Cell(i + 1, 2).Value = item.MovieName.ToString();
                        worksheet.Cell(i + 1, 3).Value = item.TicketPrice.ToString();
                        worksheet.Cell(i + 1, 4).Value = item.StartDate.ToString();
                        worksheet.Cell(i + 1, 5).Value = item.EndDate.ToString();
                    }
                }
                else
                {
                    worksheet.Cell(2, 1).Value = "No tickets for selected genre!";
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, contentType, fileName);
                }

            }
        }

        public FileContentResult ExportAllTickets()
        {

            string fileName = "AllTickets.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("AllTickets");

                worksheet.Cell(1, 1).Value = "Ticket Id";
                worksheet.Cell(1, 2).Value = "Movie Name";
                worksheet.Cell(1, 3).Value = "Movie Genre";
                worksheet.Cell(1, 4).Value = "Ticket Price";
                worksheet.Cell(1, 5).Value = "Streaming Start Date";
                worksheet.Cell(1, 6).Value = "Streaming End Date";


                var result = _ticketService.GetAllTickets()
                .Where(z => z.StartDate <= DateTime.Now && z.EndDate >= DateTime.Now).ToList();

                if (result.Count > 0)
                {
                    for (int i = 1; i <= result.Count(); i++)
                    {
                        var item = result[i - 1];

                        worksheet.Cell(i + 1, 1).Value = item.Id.ToString();
                        worksheet.Cell(i + 1, 2).Value = item.MovieName.ToString();
                        worksheet.Cell(i + 1, 3).Value = item.MovieGenre.ToString();
                        worksheet.Cell(i + 1, 4).Value = item.TicketPrice.ToString();
                        worksheet.Cell(i + 1, 5).Value = item.StartDate.ToString();
                        worksheet.Cell(i + 1, 6).Value = item.EndDate.ToString();
                    }
                }
                else
                {
                    worksheet.Cell(2, 1).Value = "No tickets!";
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, contentType, fileName);
                }

            }
        }
    }
}

