namespace LawFirm.DTO
{
    using System;

    public class DetailedProtocol
    {
        public DetailedProtocol()
        {
        }

        public DetailedProtocol(DateTime dateOfBeginning, string customer, string service, decimal cost)
        {
            this.DateOfBeginning = dateOfBeginning;
            this.Customer = customer;
            this.Service = service;
            this.Cost = cost;
        }

        public DateTime DateOfBeginning { get; set; }

        public string Customer { get; set; }

        public string Service { get; set; }

        public decimal Cost { get; set; }

        public override string ToString()
        {
            return $"Дата: {this.DateOfBeginning}, \nКлиент: {this.Customer}, \nУслуга: {this.Service}, \nСтоимость: {this.Cost}";
        }
    }
}