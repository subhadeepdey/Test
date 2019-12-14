using FDDWeb.DAO;
using FDDWeb.Models;
using FDDWeb.Utility;
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

        IList<Order> GetOrders(string username = null);

        bool UpdateOrderStatus(Guid orderID, string orderStatus);

        bool CanOrderStatusChange(string orderStatus);
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

        public IList<Order> GetOrders(string username = null) => orderDao.GetOrders(username);

        public bool UpdateOrderStatus(Guid orderID, string orderStatus) => orderDao.UpdateOrderStatus(orderID, orderStatus);

        public bool CanOrderStatusChange(string orderStatus) => !string.Equals(orderStatus, Constants.APPROVED_ORDER_STATUS) && !string.Equals(orderStatus, Constants.CANCELED_ORDER_STATUS);
    }
}