namespace LawFirm.Domain
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Услуга
    /// </summary>
    public class Service : DomainObject
    {
        public Service()
        {
        }

        public Service(long serviceId, string name, string description, decimal cost)
        {
            this.ServiceId = serviceId;
            this.Name = name;
            this.Description = description;
            this.Cost = cost;
        }

        /// <summary>
        /// Id
        /// </summary>
        [DisplayName("Id")]
        public long ServiceId { get; set; }

        /// <summary>
        /// Наименование услуги
        /// </summary>
        [DisplayName("Наименование услуги")]
        [StringLength(50, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [DisplayName("Описание")]
        [StringLength(100, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        [DisplayName("Стоимость")]
        [Required(AllowEmptyStrings = false)]
        public decimal Cost { get; set; }

        public override string ToString()
        {
            return $"ServiceId: {this.ServiceId}, Name: {this.Name}, Description: {this.Description}, Cost: {this.Cost}";
        }
    }
}