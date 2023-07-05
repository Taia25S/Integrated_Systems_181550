using CinemaApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Service.Interface
{
    public interface IUserService
    {
        bool ChangeUserRole(string userId);
        List<CinemaApplicationUser> findAll();
        bool IsAdmin(string userId);
    }
}
