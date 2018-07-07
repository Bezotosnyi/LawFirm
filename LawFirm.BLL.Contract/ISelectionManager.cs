namespace LawFirm.BLL.Contract
{
    using System;
    using System.Collections.Generic;

    using LawFirm.Domain;
    using LawFirm.DTO;

    public interface ISelectionManager
    {
        IEnumerable<OrderDto> GetOrdersByCustomerAndPeriod(
            Customer customer,
            DateTime dateOfBeginning,
            DateTime expirationDate);
    }
}