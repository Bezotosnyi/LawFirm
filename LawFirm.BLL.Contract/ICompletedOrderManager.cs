namespace LawFirm.BLL.Contract
{
    using System.Collections.Generic;

    using LawFirm.DTO;

    public interface ICompletedOrderManager
    {
        void AddCompletedOrder(long orderId, decimal expenses);

        IEnumerable<CompletedOrderDto> GetAllCompletedOrder(IEnumerable<OrderDto> orderDtoes);
    }
}