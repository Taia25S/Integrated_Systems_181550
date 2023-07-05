using CinemaTisketingSystemAdmin_191010.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
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
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ImportUsers(IFormFile file)
        {
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";
            using(FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            List<User> users = getAllUsersFromFile(file.FileName);

            HttpClient client = new HttpClient();

            string URL = "https://localhost:44360/api/admin/ImportAllUsers";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            return RedirectToAction("Index", "Order");
        }

        private List<User> getAllUsersFromFile(string fileName)
        {
            string path = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";
            List<User> users = new List<User>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using(var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        users.Add(new Models.User
                        {
                            Email = reader.GetValue(0).ToString(),
                            Password = reader.GetValue(1).ToString(),
                            Role = reader.GetValue(2).ToString()

                        });
                    }
                }
            }
            return users;
        }
    }
}
