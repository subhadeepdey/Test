using FDDWeb.DAO;
using FDDWeb.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace FDDWeb.BLL
{
    public interface IOrderLogic
    {
        bool AddMenuToOrder(string username, Guid menuID, int quantity);

        bool PlaceOrder(string username);
        IList<Order> GetCurrentOrder(string username);
    }

    public class OrderLogic : IOrderLogic
    {
        public IOrderDao orderDao { get; set; }

        public OrderLogic(IOrderDao orderDao)
        {
            this.orderDao = orderDao;
        }
        public bool AddMenuToOrder(string username, Guid menuID, int quantity) => orderDao.AddMenuToOrder(username, menuID, quantity);

        public bool PlaceOrder(string username) => orderDao.PlaceOrder(username);

        public IList<Order> GetCurrentOrder(string username) => orderDao.GetCurrentOrder(username);

    }
}