namespace LawFirm.DTO
{
    using System.ComponentModel;

    public class ShortOrderDto
    {
        public ShortOrderDto()
        {
        }

        public ShortOrderDto(long orderId, string service)
        {
            this.OrderId = orderId;
            this.Service = service;
        }

        [DisplayName("Id")]
        public long OrderId { get; set; }

        [DisplayName("Услуга")]
        public string Service { get; set; }

        public override string ToString()
        {
            return $"OrderId: {this.OrderId}, Service: {this.Service}";
        }
    }
}