namespace LawFirm.UnitTests.BLL
{
    using LawFirm.BLL;
    using LawFirm.BLL.Contract;
    using LawFirm.DAL;
    using LawFirm.DAL.Contract;
    using LawFirm.DAL.MsSqlServer;
    using LawFirm.Domain;

    using NUnit.Framework;

    [TestFixture]
    public class UserManagerTester
    {
        private IUserManager userManager;

        [SetUp]
        public void SetUp()
        {
            IDalManager dalManager = new MsSqlDalManager("Data Source=DIMA; Initial Catalog=LawFirm;Integrated Security=True");
            IRepository<User> userRepository = new UserRepository(dalManager);
            this.userManager = new UserManager(userRepository);
        }

        [Test]
        public void RegistrationTest()
        {
            var name = "Ivan";
            var lastName = "Ivanov";
            var login = "test";
            var password = "test";

            Assert.DoesNotThrow(() => this.userManager.Registration(name, lastName, login, password));
        }

        [Test]
        public void LoginTest()
        {
            var login = "admin";
            var password = "admin";
            var success = this.userManager.Login(login, password);
            Assert.IsTrue(success);
        }
    }
}