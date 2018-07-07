namespace LawFirm.UnitTests.DAL
{
    using System;

    using LawFirm.DAL;
    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    using NUnit.Framework;

    [TestFixture]
    public class CustomerRepositoryTester
    {
        private IRepository<Customer> customerRepository;

        [SetUp]
        public void SetUp()
        {
            var dalManagerFactory = new DalManagerFactory();
            var repositoryFactory = new RepositoryFactory();
            this.customerRepository = repositoryFactory.GetRepository<Customer>(
                dalManagerFactory.GetMsSqlServerDalManager(
                    "Data Source=DIMA; Initial Catalog=LawFirm;Integrated Security=True"));
        }

        [Test]
        public void InsertCustomerRepositoryTest()
        {
            var customer = new Customer
                               {
                                   LastName = "Ivanov",
                                   Name = "Ivan",
                                   Patronymic = "Ivanovych",
                                   Address = "Dnepr",
                                   ContactPhone = "+380677777777",
                                   ContactPhone2 = "+380977777777"
            };

            var id = this.customerRepository.Insert(customer);
            Assert.IsTrue(id > 0);
        }

        [Test]
        public void SelectAllCustomerRepositoryTest()
        {
            var customers = this.customerRepository.SelectAll();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }

            Assert.AreNotEqual(null, customers);
        }
    }
}