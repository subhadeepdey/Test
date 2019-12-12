using FDDWeb.DAO;
using FDDWeb.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace FDDWeb.BLL
{
    public interface IOrderLogic
    {
        bool AddMenuToOrder(Guid menuID, int quantity);
    }

    public class OrderLogic : IOrderLogic
    {
        public IOrderDao orderDao { get; set; }

        public OrderLogic(IOrderDao orderDao)
        {
            this.orderDao = orderDao;
        }
        public bool AddMenuToOrder(Guid menuID, int quantity)
        {
            return orderDao.AddMenuToOrder(HttpContext.Current.User.Identity.Name, menuID, quantity);
        }
    }
}