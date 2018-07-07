namespace LawFirm.Domain
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Клиент
    /// </summary>
    public class Customer : DomainObject
    {
        public Customer()
        {
        }

        public Customer(long customerId, string lastName, string name, string patronymic, string address, string contactPhone, string contactPhone2)
        {
            this.CustomerId = customerId;
            this.LastName = lastName;
            this.Name = name;
            this.Patronymic = patronymic;
            this.Address = address;
            this.ContactPhone = contactPhone;
            this.ContactPhone2 = contactPhone2;
        }

        /// <summary>
        /// Id клиента
        /// </summary>
        [DisplayName("Id клиента")]
        public long CustomerId { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилие")]
        [StringLength(50, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DisplayName("Имя")]
        [StringLength(50, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DisplayName("Отчество")]
        [StringLength(50, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string Patronymic { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        [DisplayName("Адрес")]
        [StringLength(100, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }

        /// <summary>
        /// Контактный телефон
        /// </summary>
        [DisplayName("Контактный телефон")]
        [Phone]
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^\+?(38|8)?\(?0\d{2}\)?\-?\d{3}\-?\d{2}\-?\d{2}$")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Контактный телефон 2
        /// </summary>
        [DisplayName("Контактный телефон 2")]
        [Phone]
        [RegularExpression(@"^\+?(38|8)?\(?0\d{2}\)?\-?\d{3}\-?\d{2}\-?\d{2}$")]
        public string ContactPhone2 { get; set; }

        public override string ToString()
        {
            return $"CustomerId: {this.CustomerId}, LastName: {this.LastName}, Name: {this.Name}, Patronymic: {this.Patronymic}, "
                   + $"Address: {this.Address}, ContactPhone: {this.ContactPhone}, ContactPhone2: {this.ContactPhone2}";
        }
    }
}