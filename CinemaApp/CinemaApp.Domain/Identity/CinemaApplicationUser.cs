using CinemaApp.Domain.Domain_Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Identity
{
    public enum Role
    {
        ROLE_ADMIN,
        ROLE_USER
    }
    public class CinemaApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserShoppingCart { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Role Role { get; set; } = Role.ROLE_USER;

    }
}
