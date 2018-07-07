namespace LawFirm.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using LawFirm.BLL.Contract;
    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class CustomerManager : ICustomerManager
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomerManager(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void AddCustomer(
            string lastName,
            string name,
            string patronymic,
            string address,
            string contactPhone,
            string contactPhone2)
        {
            var customer = new Customer
                               {
                                   LastName = lastName,
                                   Name = name,
                                   Patronymic = patronymic,
                                   Address = address,
                                   ContactPhone = contactPhone,
                                   ContactPhone2 = contactPhone2
                               };

            var validationResult = new List<ValidationResult>();

            // валидация
            if (!Validator.TryValidateObject(customer, new ValidationContext(customer), validationResult, true))
            {
                var error = validationResult.Select(x => x.ErrorMessage).Aggregate((x, y) => x + "\n" + y);
                throw new ArgumentException(error);
            }

            var customers = this.customerRepository.SelectAll();

            // проверка на существования
            if (customers.Any(
                x => x.LastName == customer.LastName && x.Name == customer.Name && x.Patronymic == customer.Patronymic
                     && x.Address == customer.Address && x.ContactPhone == customer.ContactPhone))
            {
                throw new ArgumentException("Такой клиент уже существует.");
            }

            this.customerRepository.Insert(customer); // добавление нового
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return this.customerRepository.SelectAll();
        }
    }
}