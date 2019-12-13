using FDDWeb.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FDDWeb.BLL.Tests
{
    [TestClass()]
    public class UserLogicTests
    {

        public IUserLogic userLogic { get; set; }

        public Mock<IUserDao> userDao { get; set; }

        [TestInitialize]
        public void Setup()
        {
            userDao = new Mock<IUserDao>();
            userLogic = new UserLogic(userDao.Object);
        }

        [TestMethod()]
        public void RegisterTest()
        {
            userDao.Setup(u => u.IsValidUser(
                "Admin1", "12345")).Returns(new Models.User());
            Assert.IsNotNull(userLogic.IsValidUser("Admin1", "12345"));
        }
    }
}