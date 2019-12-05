using FDDWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDDWeb.DAO
{
    public interface IUserDao
    {
        bool Register(ApplicationUser user);
    }

    public class UserDao : IUserDao
    {
        public bool Register(ApplicationUser user)
        {
            return true;
        }
    }
}