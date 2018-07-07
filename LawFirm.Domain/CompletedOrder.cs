namespace LawFirm.Domain
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Выполненые заказы
    /// </summary>
    public class CompletedOrder : DomainObject
    {
        public CompletedOrder()
        {
        }

        public CompletedOrder(long completedOrderId, long orderId, decimal expenses)
        {
            this.CompletedOrderId = completedOrderId;
            this.OrderId = orderId;
            this.Expenses = expenses;
        }

        /// <summary>
        /// Id выполненого заказа
        /// </summary>
        [DisplayName("Id выполненого заказа")]
        public long CompletedOrderId { get; set; }

        /// <summary>
        /// Id заказа
        /// </summary>
        [DisplayName("Id заказа")]
        [Required(AllowEmptyStrings = false)]
        public long OrderId { get; set; }

        /// <summary>
        /// Затраты
        /// </summary>
        [DisplayName("Затраты")]
        [Required(AllowEmptyStrings = false)]
        public decimal Expenses { get; set; }

        public override string ToString()
        {
            return $"CompletedOrderId: {this.CompletedOrderId}, OrderId: {this.OrderId}, Expenses: {this.Expenses}";
        }
    }
}