namespace LawFirm.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LawFirm.BLL.Contract;
    using LawFirm.Domain;
    using LawFirm.DTO;

    public class SelectionManager : ISelectionManager
    {
        private readonly IOrderManager orderManager;

        public SelectionManager(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        public IEnumerable<OrderDto> GetOrdersByCustomerAndPeriod(Customer customer, DateTime dateOfBeginning, DateTime expirationDate)
        {
            var ordersIds = this.orderManager.GetAllOrders()
                .Where(x => x.CustomerId == customer.CustomerId && x.DateOfBeginning >= dateOfBeginning && x.ExpirationDate <= expirationDate)
                .Select(x => x.OrderId).ToList();

            return this.orderManager.GetAllOrderDtoes().Where(x => x.OrderId == ordersIds.Find(id => x.OrderId == id));
        }
    }
}