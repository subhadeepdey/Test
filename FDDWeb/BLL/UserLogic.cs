using FDDWeb.DAO;
using FDDWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDDWeb.BLL
{
    public interface IUserLogic
    {
        bool Register(ApplicationUser user);
    }
    public class UserLogic : IUserLogic
    {
        public IUserDao userDao { get; set; }

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public bool Register(ApplicationUser user) => userDao.Register(user);
    }
}