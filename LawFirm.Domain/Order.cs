namespace LawFirm.Domain
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Заказ
    /// </summary>
    public class Order : DomainObject
    {
        public Order()
        {
        }

        public Order(long orderId, DateTime dateOfBeginning, DateTime expirationDate, long customerId, long lawyerId)
        {
            this.OrderId = orderId;
            this.DateOfBeginning = dateOfBeginning;
            this.ExpirationDate = expirationDate;
            this.CustomerId = customerId;
            this.LawyerId = lawyerId;
        }

        /// <summary>
        /// Id
        /// </summary>
        [DisplayName("Id")]
        public long OrderId { get; set; }

        /// <summary>
        /// Дата начала
        /// </summary>
        [DisplayName("Дата начала")]
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false)]
        public DateTime DateOfBeginning { get; set; }

        /// <summary>
        /// Дата окончания
        /// </summary>
        [DisplayName("Дата окончания")]
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false)]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Клиент
        /// </summary>
        [DisplayName("Клиент id")]
        [Required(AllowEmptyStrings = false)]
        public long CustomerId { get; set; }

        /// <summary>
        /// Юрист
        /// </summary>
        [DisplayName("Юрист id")]
        [Required(AllowEmptyStrings = false)]
        public long LawyerId { get; set; }

        public override string ToString()
        {
            return $"OrderId: {this.OrderId}, DateOfBeginning: {this.DateOfBeginning}, "
                   + $"ExpirationDate: {this.ExpirationDate}, CustomerId: {this.CustomerId}, LawyerId: {this.LawyerId}";
        }
    }
}