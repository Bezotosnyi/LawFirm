namespace LawFirm.BLL.Contract
{
    using System.Collections.Generic;

    using LawFirm.Domain;

    public interface ICustomerManager
    {
        void AddCustomer(
            string lastName,
            string name,
            string patronymic,
            string address,
            string contactPhone,
            string contactPhone2);

        IEnumerable<Customer> GetAllCustomers();
    }
}