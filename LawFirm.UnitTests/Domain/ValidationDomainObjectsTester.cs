namespace LawFirm.UnitTests.Domain
{
    using System.ComponentModel.DataAnnotations;

    using LawFirm.Domain;

    using NUnit.Framework;

    [TestFixture]
    public class ValidationDomainObjectsTester
    {
        [Test]
        public void TestCustomerValidation()
        {
            var customer = new Customer
                               {
                                   CustomerId = 1,
                                   LastName = "Ivanov",
                                   Name = "Ivan",
                                   Patronymic = "Ivanovych",
                                   Address = "Dnepr",
                                   ContactPhone = "345678" // wrong
                               };

            var valid = Validator.TryValidateObject(customer, new ValidationContext(customer), null, true);
            Assert.AreEqual(false, valid);

            customer.ContactPhone = "0677777777"; // correct
            valid = Validator.TryValidateObject(customer, new ValidationContext(customer), null, true);
            Assert.AreEqual(true, valid);
        }
    }
}