using CinemaTisketingSystemAdmin_191010.Models;
using ClosedXML.Excel;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTisketingSystemAdmin_191010.Controllers
{
    public class OrderController : Controller
    {
        public OrderController()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            string URL = "https://localhost:44360/api/admin/GetAllActiveOrders";

            HttpResponseMessage response = client.GetAsync(URL).Result;

            var data = response.Content.ReadAsAsync<List<Order>>().Result;

            return View(data);
        }
        public IActionResult GetOrderDetails(int id)
        {
            HttpClient client = new HttpClient();

            string URL = "https://localhost:44360/api/admin/GetOrderDetails";

            var model = new
            {
                Id = id
            };

            
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var data = response.Content.ReadAsAsync <Order>().Result;

            return View(data);
        }

        public FileResult SavePdf(int id)
        {
            HttpClient client = new HttpClient();

            string URL = "https://localhost:44360/api/admin/GetOrderDetails";

            var model = new
            {
                Id = id
            };


            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Order>().Result;
            var directoryPath = Directory.GetCurrentDirectory();
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");

            var document = DocumentModel.Load(templatePath);

            document.Content.Replace("{{OrderNumber}}", result.Id.ToString());
            document.Content.Replace("{{UserName}}", result.OrderedBy.Username);

            StringBuilder sb = new StringBuilder();
            int totalPrice = 0;
            foreach (var item in result.TicketsInOrder)
            {
                totalPrice += item.Quantity * item.Ticket.TicketPrice;
                sb.AppendLine(item.Ticket.MovieName+ ", Quantity: "+ item.Quantity+", Price: "+ item.Ticket.TicketPrice);
            }

            document.Content.Replace("{{TicketList}}", sb.ToString());
            document.Content.Replace("{{TotalPrice}}", totalPrice.ToString());

            var stream = new MemoryStream();

            document.Save(stream, new PdfSaveOptions());


            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }

        [HttpGet]
        public FileContentResult ExportAllOrders()
        {
            string fileName = "Orders.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using(var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("All Orders");

                worksheet.Cell(1, 1).Value = "Order Id";
                worksheet.Cell(1, 2).Value = "Customer Email";

                HttpClient client = new HttpClient();

                string URL = "https://localhost:44360/api/admin/GetAllActiveOrders";

                HttpResponseMessage response = client.GetAsync(URL).Result;

                var data = response.Content.ReadAsAsync<List<Order>>().Result;

                for (int i = 1; i <= data.Count(); i++)
                {
                    var item = data[i-1];
                    worksheet.Cell(i+1, 1).Value = item.Id.ToString();
                    worksheet.Cell(i+1, 2).Value = item.OrderedBy.Email;

                    for (int t = 0; t < item.TicketsInOrder.Count(); t++)
                    {
                        worksheet.Cell(1, t+3).Value = "Ticket- "+ (t+1);
                        worksheet.Cell(i + 1, t + 3).Value = item.TicketsInOrder.ElementAt(t).Ticket.MovieName;
                    }
                }

                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, contentType, fileName);
                }
            }

        }




    }
}
