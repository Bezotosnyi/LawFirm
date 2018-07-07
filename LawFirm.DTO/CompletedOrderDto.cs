namespace LawFirm.DTO
{
    using System;
    using System.ComponentModel;

    public class CompletedOrderDto
    {
        public CompletedOrderDto()
        {
        }

        public CompletedOrderDto(
            long orderId,
            string service,
            DateTime dateOfBeginning,
            DateTime expirationDate,
            string customer,
            string lawyer,
            decimal income,
            decimal expenses)
        {
            this.OrderId = orderId;
            this.Service = service;
            this.DateOfBeginning = dateOfBeginning;
            this.ExpirationDate = expirationDate;
            this.Customer = customer;
            this.Lawyer = lawyer;
            this.Income = income;
            this.Expenses = expenses;
        }

        [DisplayName("Id")]
        public long OrderId { get; set; }

        [DisplayName("Услуга")]
        public string Service { get; set; }

        [DisplayName("Дата начала")]
        public DateTime DateOfBeginning { get; set; }

        [DisplayName("Дата окончания")]
        public DateTime ExpirationDate { get; set; }

        [DisplayName("Клиент")]
        public string Customer { get; set; }

        [DisplayName("Юрист")]
        public string Lawyer { get; set; }

        [DisplayName("Доход")]
        public decimal Income { get; set; }

        [DisplayName("Затраты")]
        public decimal Expenses { get; set; }

        public override string ToString()
        {
            return $"OrderId: {this.OrderId}, Service: {this.Service}, DateOfBeginning: {this.DateOfBeginning}, "
                   + $"ExpirationDate: {this.ExpirationDate}, Customer: {this.Customer}, Lawyer: {this.Lawyer}, "
                   + $"Income: {this.Income}, Expenses: {this.Expenses}";
        }
    }
}