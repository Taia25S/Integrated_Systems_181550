using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Identity
{
    public class UserRegistrationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public Role UserRole;
    }
}
