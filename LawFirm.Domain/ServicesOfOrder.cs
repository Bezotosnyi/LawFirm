namespace LawFirm.Domain
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Услуги заказа
    /// </summary>
    public class ServicesOfOrder : DomainObject
    {
        public ServicesOfOrder()
        {
        }

        public ServicesOfOrder(long servicesOfOrderId, long orderId, long serviceId)
        {
            this.ServicesOfOrderId = servicesOfOrderId;
            this.OrderId = orderId;
            this.ServiceId = serviceId;
        }

        /// <summary>
        /// Id услуги заказа
        /// </summary>
        [DisplayName("Id услуги заказа")]
        public long ServicesOfOrderId { get; set; }

        /// <summary>
        /// Заказ
        /// </summary>
        [DisplayName("Заказ id")]
        [Required(AllowEmptyStrings = false)]
        public long OrderId { get; set; }

        /// <summary>
        /// Услуга
        /// </summary>
        [DisplayName("Услуга id")]
        [Required(AllowEmptyStrings = false)]
        public long ServiceId { get; set; }

        public override string ToString()
        {
            return $"ServicesOfOrderId: {this.ServicesOfOrderId}, OrderId: {this.OrderId}, ServiceId: {this.ServiceId}";
        }
    }
}