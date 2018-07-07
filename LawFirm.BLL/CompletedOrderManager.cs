namespace LawFirm.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using LawFirm.BLL.Contract;
    using LawFirm.DAL.Contract;
    using LawFirm.Domain;
    using LawFirm.DTO;

    public class CompletedOrderManager : ICompletedOrderManager
    {
        private readonly IRepository<CompletedOrder> completedOrderRepository;

        public CompletedOrderManager(IRepository<CompletedOrder> completedOrderRepository)
        {
            this.completedOrderRepository = completedOrderRepository;
        }

        public void AddCompletedOrder(long orderId, decimal expenses)
        {
            var completedOrder = new CompletedOrder { OrderId = orderId, Expenses = expenses };
            var validationResult = new List<ValidationResult>();

            // валидация
            if (!Validator.TryValidateObject(completedOrder, new ValidationContext(completedOrder), validationResult, true))
            {
                var error = validationResult.Select(x => x.ErrorMessage).Aggregate((x, y) => x + "\n" + y);
                throw new ArgumentException(error);
            }

            this.completedOrderRepository.Insert(completedOrder); // добавление нового
        }

        public IEnumerable<CompletedOrderDto> GetAllCompletedOrder(IEnumerable<OrderDto> orderDtoes)
        {
            var completedOrders = this.completedOrderRepository.SelectAll().ToList();

            if (completedOrders.Count == 0)
            {
                return new List<CompletedOrderDto>();
            }

            return (from order in orderDtoes
                    let completedOrder = completedOrders.Find(x => x.OrderId == order.OrderId)
                    where completedOrder != null
                    select new CompletedOrderDto
                               {
                                   Customer = order.Customer,
                                   DateOfBeginning = order.DateOfBeginning,
                                   Expenses = completedOrder.Expenses,
                                   ExpirationDate = order.ExpirationDate,
                                   Income = order.Cost,
                                   Lawyer = order.Lawyer,
                                   OrderId = order.OrderId,
                                   Service = order.Service
                               }).ToList();
        }
    }
}