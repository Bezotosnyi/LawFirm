namespace LawFirm.BLL.Contract
{
    using System;
    using System.Collections.Generic;

    using LawFirm.Domain;
    using LawFirm.DTO;

    public interface IOrderManager
    {
        void AddOrder(
            IEnumerable<Service> servicesOfOrders,
            DateTime dateOfBeginning,
            DateTime expirationDate,
            long customerId,
            long lawyerId);

        IEnumerable<OrderDto> GetAllOrderDtoes();

        IEnumerable<Order> GetAllOrders();
    }
}