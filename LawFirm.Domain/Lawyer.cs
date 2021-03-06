﻿namespace LawFirm.Domain
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Юрист
    /// </summary>
    public class Lawyer : DomainObject
    {
        public Lawyer()
        {
        }

        public Lawyer(long lawyerId, string lastName, string name, string patronymic, string address, string contactPhone, string contactPhone2, DateTime hireDate)
        {
            this.LawyerId = lawyerId;
            this.LastName = lastName;
            this.Name = name;
            this.Patronymic = patronymic;
            this.Address = address;
            this.ContactPhone = contactPhone;
            this.ContactPhone2 = contactPhone2;
            this.HireDate = hireDate;
        }

        /// <summary>
        /// Id юриста
        /// </summary>
        [DisplayName("Id юриста")]
        public long LawyerId { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
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
        [Phone]
        [DisplayName("Контактный телефон")]
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^\+?(38|8)?\(?0\d{2}\)?\-?\d{3}\-?\d{2}\-?\d{2}$")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Контактный телефон 2
        /// </summary>
        [Phone]
        [DisplayName("Контактный телефон 2")]
        [RegularExpression(@"^\+?(38|8)?\(?0\d{2}\)?\-?\d{3}\-?\d{2}\-?\d{2}$")]
        public string ContactPhone2 { get; set; }

        /// <summary>
        /// Дата приема на работу
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayName("Дата приема на работу")]
        [Required(AllowEmptyStrings = false)]
        public DateTime HireDate { get; set; }

        public override string ToString()
        {
            return $"LawyerId: {this.LawyerId}, LastName: {this.LastName}, Name: {this.Name}, Patronymic: {this.Patronymic}, "
                   + $"Address: {this.Address}, ContactPhone: {this.ContactPhone}, ContactPhone2: {this.ContactPhone2}, HireDate: {this.HireDate}";
        }
    }
}