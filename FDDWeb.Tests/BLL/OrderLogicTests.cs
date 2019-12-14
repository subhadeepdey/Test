using FDDWeb.BLL;
using FDDWeb.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FDDWeb.BLL.Tests
{
    [TestClass()]
    public class OrderLogicTests
    {
        public IOrderLogic orderLogic { get; set; }

        public IOrderDao orderDao { get; set; }

        [TestInitialize]
        public void Setup()
        {
            orderDao = new OrderDao();
            orderLogic = new OrderLogic(orderDao);
        }

        [TestMethod()]
        public void AddMenuToOrderTest()
        {
            Assert.IsTrue(orderLogic.AddMenuToOrder("Customer", new Guid("619902D2-B001-4094-8FD3-3AEA06D71FA0"), 1));
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            Assert.IsTrue(orderLogic.PlaceOrder("Customer"));

        }

        [TestMethod()]
        public void GetCurrentOrderTest()
        {
            var retVal = orderLogic.GetCurrentOrder("Admin");
            Assert.AreNotEqual(retVal.Count, 0);
        }

        [TestMethod()]
        public void GetOrdersTest()
        {
            var retVal = orderLogic.GetOrders();
            Assert.AreNotEqual(retVal.Count, 0);
        }

        [TestMethod()]
        public void UpdateOrderStatusTest()
        {
            Assert.IsTrue(orderLogic.UpdateOrderStatus(new Guid("99E7B098-22A9-4DB2-A0ED-29FDFB2BC833"), "APPROVED"));

        }

        [TestMethod()]
        public void CanOrderStatusChangeTest()
        {
            Assert.IsTrue(orderLogic.CanOrderStatusChange("ADDED_TO_CART"));

        }
    }
}