using FDDWeb.BLL;
using FDDWeb.DAO;
using FDDWeb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FDDWeb.BLL.Tests
{
    [TestClass()]
    public class UserLogicTests : TestBase
    {
        public IUserLogic userLogic { get; set; }

        public IUserDao userDao { get; set; }

        [TestInitialize]
        public void Setup()
        {
            userDao = new UserDao();
            userLogic = new UserLogic(userDao);
        }

        [TestMethod()]
        public void RegisterTest()
        {
            var user = userLogic.Register(new Models.User
            {
                Address = "Test Address",
                AlternateAddress = "Alternate Address",
                Email = "test@test.com",
                Name = "Test User",
                Password = "password",
                Phone = "123445678",
                Username = "test",
                Role = Constants.DEFAULT_ROLE
            });
            Assert.IsNotNull(user);
            Assert.AreEqual(user.Username, "test");
        }

        [TestMethod()]
        public void IsValidUserTest()
        {
            var user = userLogic.IsValidUser("Admin", "password");
            Assert.IsNotNull(user);
            Assert.AreEqual(user.Username, "Admin");
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            var users = userLogic.GetUsers();
            Assert.AreNotEqual(users.Count, 0);
        }

        [TestMethod()]
        public void UpgradeToPremiumTest()
        {
            Assert.IsTrue(userLogic.UpgradeToPremium("Customer"));
        }
    }
}