using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDDWeb.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AlternateAddress { get; set; }
        public LoginStatus Status { get; set; }
        public string Role { get; set; }

    }
}