using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDDWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDDWeb.DAO;

namespace FDDWeb.BLL.Tests
{
    [TestClass()]
    public class MenuLogicTests
    {
        public IMenuLogic menuLogic { get; set; }

        public IMenuDao menuDao { get; set; }

        [TestInitialize]
        public void Setup()
        {
            menuDao = new MenuDao();
            menuLogic = new MenuLogic(menuDao);
        }

        [TestMethod()]
        public void GetMenuTest()
        {
            Assert.AreNotEqual(menuLogic.GetMenu().Count, 0);
        }

        [TestMethod()]
        public void AddMenuTest()
        {
            Assert.IsTrue(menuLogic.AddMenu(new Models.MenuItem
            {
                Name = "Samosa",
                Price = 2,
                Description = "snacks",
                FoodCategoryID = new Guid("7F923E4A-27EA-4B8D-8575-4BAC763F715F")
            }));
        }

        [TestMethod()]
        public void GetFoodCategoriesTest()
        {
            Assert.AreNotEqual(menuLogic.GetFoodCategories().Count, 0);
        }

        [TestMethod()]
        public void DeleteMenuTest()
        {
            Assert.IsTrue(menuLogic.DeleteMenu(new Guid("D763E4D4-851B-4307-9B37-50BEACCD4A41")));
        }
    }
}