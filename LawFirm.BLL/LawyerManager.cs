namespace LawFirm.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using LawFirm.BLL.Contract;
    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class LawyerManager : ILawyerManager
    {
        private readonly IRepository<Lawyer> lawyerRepository;

        public LawyerManager(IRepository<Lawyer> lawyerRepository)
        {
            this.lawyerRepository = lawyerRepository;
        }

        public void AddLawyer(
            string lastName,
            string name,
            string patronymic,
            string address,
            string contactPhone,
            string contactPhone2,
            DateTime hireDate)
        {
            var lawyer = new Lawyer
                               {
                                   LastName = lastName,
                                   Name = name,
                                   Patronymic = patronymic,
                                   Address = address,
                                   ContactPhone = contactPhone,
                                   ContactPhone2 = contactPhone2,
                                   HireDate = hireDate
                               };

            var validationResult = new List<ValidationResult>();

            // валидация
            if (!Validator.TryValidateObject(lawyer, new ValidationContext(lawyer), validationResult, true))
            {
                var error = validationResult.Select(x => x.ErrorMessage).Aggregate((x, y) => x + "\n" + y);
                throw new ArgumentException(error);
            }

            var customers = this.lawyerRepository.SelectAll();

            // проверка на существования
            if (customers.Any(
                x => x.LastName == lawyer.LastName && x.Name == lawyer.Name && x.Patronymic == lawyer.Patronymic
                     && x.Address == lawyer.Address && x.ContactPhone == lawyer.ContactPhone))
            {
                throw new ArgumentException("Такой юрист уже существует.");
            }

            this.lawyerRepository.Insert(lawyer); // добавление нового
        }

        public IEnumerable<Lawyer> GetAlLawyers()
        {
            return this.lawyerRepository.SelectAll();
        }
    }
}