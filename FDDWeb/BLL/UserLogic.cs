using FDDWeb.DAO;
using FDDWeb.Models;
using FDDWeb.Utility;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDDWeb.BLL
{
    public interface IUserLogic
    {
        User Register(User user);
        User IsValidUser(string username, string password);
        IList<User> GetUsers();
        bool UpgradeToPremium(string username);
    }
    public class UserLogic : IUserLogic
    {
        public IUserDao userDao { get; set; }

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public User Register(User user) => userDao.Register(user);

        public User IsValidUser(string username, string password) => userDao.IsValidUser(username, password);

        public IList<User> GetUsers()
        {
            var users = userDao.GetUsers();
            return users.Where(u => u.Role != Constants.ADMIN_ROLE && !u.IsPremium).ToList();
        }

        public bool UpgradeToPremium(string username) => userDao.UpgradeToPremium(username);
    }
}