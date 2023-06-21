using CinemaApp.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Web.Controllers
{
    public class RoleAccountController : Controller
    {
        private readonly UserManager<CinemaApplicationUser> userManager;
        private readonly SignInManager<CinemaApplicationUser> signInManager;
        public RoleAccountController(UserManager<CinemaApplicationUser> userManager, SignInManager<CinemaApplicationUser> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult ChangeUserRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserRole(CinemaApplicationUser cinemaUser)
        {
            var updatedUser = await userManager.FindByIdAsync(cinemaUser.Id);
            updatedUser.Role = cinemaUser.Role;
            var result = await userManager.UpdateAsync(updatedUser);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
               return View(cinemaUser);
            }
        }
    }
}
