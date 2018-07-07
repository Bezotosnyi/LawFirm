namespace LawFirm.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using LawFirm.BLL.Contract;
    using LawFirm.DAL.Contract;
    using LawFirm.Domain;
    using LawFirm.DTO;

    public class OrderManager : IOrderManager
    {
        private readonly IRepository<Order> orderRepository;

        private readonly IRepository<ServicesOfOrder> servicesOfOrderRepository;

        private readonly IRepository<Customer> customerRepository;

        private readonly IRepository<Lawyer> lawyerRepository;

        private readonly IRepository<Service> serviceRepository;

        public OrderManager(
            IRepository<Order> orderRepository,
            IRepository<ServicesOfOrder> servicesOfOrderRepository,
            IRepository<Customer> customerRepository,
            IRepository<Lawyer> lawyerRepository,
            IRepository<Service> serviceRepository)
        {
            this.orderRepository = orderRepository;
            this.servicesOfOrderRepository = servicesOfOrderRepository;
            this.customerRepository = customerRepository;
            this.lawyerRepository = lawyerRepository;
            this.serviceRepository = serviceRepository;
        }

        public void AddOrder(
            IEnumerable<Service> servicesOfOrders,
            DateTime dateOfBeginning,
            DateTime expirationDate,
            long customerId,
            long lawyerId)
        {
            var order = new Order
                            {
                                DateOfBeginning = dateOfBeginning,
                                ExpirationDate = expirationDate,
                                CustomerId = customerId,
                                LawyerId = lawyerId
                            };

            var validationResult = new List<ValidationResult>();

            // валидация
            if (!Validator.TryValidateObject(order, new ValidationContext(order), validationResult, true))
            {
                var error = validationResult.Select(x => x.ErrorMessage).Aggregate((x, y) => x + "\n" + y);
                throw new ArgumentException(error);
            }

            var orderId = this.orderRepository.Insert(order); // добавление нового

            foreach (var serviceOfOrder in servicesOfOrders)
            {
                this.servicesOfOrderRepository.Insert(
                    new ServicesOfOrder { OrderId = orderId, ServiceId = serviceOfOrder.ServiceId });
            }
        }

        public IEnumerable<OrderDto> GetAllOrderDtoes()
        {
            var orders = this.orderRepository.SelectAll();
            var lawyers = this.lawyerRepository.SelectAll().ToList();
            var customers = this.customerRepository.SelectAll().ToList();
            var servicesOfOrders = this.servicesOfOrderRepository.SelectAll().ToList();
            var services = this.serviceRepository.SelectAll().ToList();

            return (from order in orders
                    let lawyer = lawyers.Find(x => x.LawyerId == order.LawyerId)
                    let customer = customers.Find(x => x.CustomerId == order.CustomerId)
                    let serviceOfOrders = servicesOfOrders.Where(x => x.OrderId == order.OrderId)
                    let cost = serviceOfOrders.Sum(id => services.Find(x => x.ServiceId == id.ServiceId).Cost)
                    let serviceNames = serviceOfOrders.Select(svc => services.Find(x => x.ServiceId == svc.ServiceId).Name)
                        .Aggregate((i1, i2) => this.FirstLetterToUpper(i1) + ", " + i2.ToLower())
                    select new OrderDto
                               {
                                   OrderId = order.OrderId,
                                   Service = serviceNames,
                                   DateOfBeginning = order.DateOfBeginning,
                                   ExpirationDate = order.ExpirationDate,
                                   Lawyer =
                                       $"{this.FirstLetterToUpper(lawyer.LastName)} {lawyer.Name.ToUpper()[0]}.{lawyer.Patronymic.ToUpper()[0]}.",
                                   Customer =
                                       $"{this.FirstLetterToUpper(customer.LastName)} {customer.Name.ToUpper()[0]}.{customer.Patronymic.ToUpper()[0]}.",
                                   Cost = cost
                               }).ToList();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return this.orderRepository.SelectAll();
        }

        private string FirstLetterToUpper(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.First().ToString().ToUpper() + str.Substring(1);
        }
    }
}