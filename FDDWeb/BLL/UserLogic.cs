using FDDWeb.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDDWeb.BLL
{
    public interface IUserLogic
    {

    }
    public class UserLogic : IUserLogic
    {
        public IUserDao userDao { get; set; }
        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }
    }
}