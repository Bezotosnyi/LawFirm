namespace LawFirm.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LawFirm.BLL.Contract;
    using LawFirm.Domain;
    using LawFirm.DTO;

    public class ReportManager : IReportManager
    {
        private readonly ICompletedOrderManager completedOrderManager;

        private readonly IOrderManager orderManager;

        public ReportManager(ICompletedOrderManager completedOrderManager, IOrderManager orderManager)
        {
            this.completedOrderManager = completedOrderManager;
            this.orderManager = orderManager;
        }

        public IEnumerable<FinanceReport> GetFinanceReportByPeriod(DateTime dateOfBeginning, DateTime expirationDate)
        {
            return this.completedOrderManager.GetAllCompletedOrder(this.orderManager.GetAllOrderDtoes())
                .Where(x => x.DateOfBeginning >= dateOfBeginning && x.ExpirationDate <= expirationDate)
                .Select(x => new FinanceReport
                                 {
                                     ServiceName = x.Service,
                                     Income = x.Income,
                                     Expenses = x.Expenses
                                 })
                .GroupBy(x => x.ServiceName)
                .Select(x => new FinanceReport
                                 {
                                     ServiceName = x.Key,
                                     Income = x.Sum(i => i.Income),
                                     Expenses = x.Sum(e => e.Expenses)
                                 });            
        }

        public IEnumerable<ShortOrderDto> GetAllShortOrderDtos()
        {
            return this.orderManager.GetAllOrderDtoes().Select(x => new ShortOrderDto(x.OrderId, x.Service));
        }

        public DetailedProtocol GetDetailedProtocol(long orderId)
        {
            return this.orderManager.GetAllOrderDtoes().Where(x => x.OrderId == orderId)
                .Select(x => new DetailedProtocol(x.DateOfBeginning, x.Customer, x.Service, x.Cost)).First();
        }
    }
}