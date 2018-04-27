using Model;
using NUnit.Framework;
using WcfService;
using CustomException;
using Dao;
using Moq;

namespace ServiceTest
{
    [TestFixture(Category="login")]
    public class TestLogin
    {
        private IUserService userService;
        private Mock<IUserDao> userDao;
        private User user = new User()
            {
                Name = "Jasper.Yue",
                Password = "e10adc3949ba59abbe56e057f20f883e",
            };

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            userDao = new Mock<IUserDao>();
            userService = new UserServiceImpl();
            userService = new UserServiceImpl(userDao.Object);

            userDao.Setup(p => p.VerifyUserLogOn("Jasper.Yue")).Returns(user);
        }
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {

        }
        [Test]
        public void TestSuccess()
        {
            User userReturn = userService.VerifyUserLogOn("Jasper.Yue", "e10adc3949ba59abbe56e057f20f883e");
            Assert.AreSame(user, userReturn);
        }
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "Username does not exist")]
        public void TestNotFound()
        {
            User userReturn = userService.VerifyUserLogOn("Jasper.Yu", "e10adc3949ba59abbe56e057f20f883e");
        }
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "Login password is incorrect")]
        public void TestPasswordNotCorrect()
        {
            User userReturn = userService.VerifyUserLogOn("Jasper.Yue", "123456");
        }
    }
}
