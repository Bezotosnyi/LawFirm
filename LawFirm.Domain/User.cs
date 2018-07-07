namespace LawFirm.Domain
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : DomainObject
    {
        public User()
        {
        }

        public User(long userId, string name, string lastName, string login, string password)
        {
            this.UserId = userId;
            this.Name = name;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
        }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [DisplayName("Id пользователя")]
        public long UserId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DisplayName("Имя")]
        [StringLength(50, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
        [StringLength(50, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [DisplayName("Логин")]
        [StringLength(50, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [DisplayName("Пароль")]
        [StringLength(50, MinimumLength = 4)]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        public override string ToString()
        {
            return $"UserId: {this.UserId}, Name: {this.Name}, LastName: {this.LastName}, Login: {this.Login}, Password: {this.Password}";
        }
    }
}