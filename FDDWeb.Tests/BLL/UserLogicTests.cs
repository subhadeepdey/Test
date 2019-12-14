using FDDWeb.BLL;
using FDDWeb.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FDDWeb.BLL.Tests
{
    [TestClass()]
    public class UserLogicTests
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
            var user = userLogic.Register(new Models.User {
                Address="Test Address",
                AlternateAddress="Alternate Address",
                Email="test@test.com",
                Name="Test User",
                Password="password",
                Phone="123445678",
                Username="test"
            });
            Assert.IsNotNull(user);
            Assert.Equals(user.Username,"test");
        }
    }
}