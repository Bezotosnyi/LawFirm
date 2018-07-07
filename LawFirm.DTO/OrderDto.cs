namespace LawFirm.DTO
{
    using System;
    using System.ComponentModel;

    public class OrderDto
    {
        public OrderDto()
        {
        }

        public OrderDto(
            long orderId,
            string service,
            DateTime dateOfBeginning,
            DateTime expirationDate,
            string customer,
            string lawyer,
            decimal cost)
        {
            this.OrderId = orderId;
            this.Service = service;
            this.DateOfBeginning = dateOfBeginning;
            this.ExpirationDate = expirationDate;
            this.Customer = customer;
            this.Lawyer = lawyer;
            this.Cost = cost;
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

        [DisplayName("Стоимость")]
        public decimal Cost { get; set; }

        public override string ToString()
        {
            return $"OrderId: {this.OrderId}, Service: {this.Service}, DateOfBeginning: {this.DateOfBeginning}, "
                   + $"ExpirationDate: {this.ExpirationDate}, Customer: {this.Customer}, Lawyer: {this.Lawyer}, Cost: {this.Cost}";
        }
    }
}