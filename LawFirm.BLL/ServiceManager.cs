namespace LawFirm.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using LawFirm.BLL.Contract;
    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class ServiceManager : IServiceManager
    {
        private readonly IRepository<Service> serviceRepository;

        public ServiceManager(IRepository<Service> serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public void AddServiceClassification(string name, string description, decimal cost)
        {
            var service = new Service { Name = name, Description = description, Cost = cost };
            var validationResult = new List<ValidationResult>();

            // валидация
            if (!Validator.TryValidateObject(service, new ValidationContext(service), validationResult, true))
            {
                var error = validationResult.Select(x => x.ErrorMessage).Aggregate((x, y) => x + "\n" + y);
                throw new ArgumentException(error);
            }

            var services = this.serviceRepository.SelectAll();

            // проверка на существования
            if (services.Any(x => x.Name == service.Name))
            {
                throw new ArgumentException("Такая услуга уже существует.");
            }

            this.serviceRepository.Insert(service); // добавление новой услуги
        }

        public IEnumerable<Service> GetAllServices()
        {
            return this.serviceRepository.SelectAll();
        }
    }
}