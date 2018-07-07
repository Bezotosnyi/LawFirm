namespace LawFirm.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using LawFirm.BLL.Contract;
    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class UserManager : IUserManager
    {
        private readonly IRepository<User> userRepository;

        public UserManager(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool Login(string login, string password)
        {
            var users = this.userRepository.SelectAll();
            return users.Any(x => x.Login == login && x.Password == password);
        }

        public void Registration(string name, string lastName, string login, string password)
        {
            var user = new User { Name = name, LastName = lastName, Login = login, Password = password };
            var validationResult = new List<ValidationResult>();

            // валидация
            if (!Validator.TryValidateObject(user, new ValidationContext(user), validationResult, true))
            {
                var error = validationResult.Select(x => x.ErrorMessage).Aggregate((x, y) => x + "\n" + y);
                throw new ArgumentException(error);
            }

            var users = this.userRepository.SelectAll();

            // проверка на существования
            if (users.Any(
                x => x.Name == user.Name && x.LastName == user.LastName && x.Login == user.Login
                     && x.Password == user.Password))
            {
                throw new ArgumentException("Такой пользователь уже существует.");
            }

            this.userRepository.Insert(user); // добавление нового
        }
    }
}