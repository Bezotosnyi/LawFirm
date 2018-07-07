namespace LawFirm.DAL
{
    using System;
    using System.Collections.Generic;

    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class RepositoryFactory : IRepositoryFactory
    {
        private static readonly Dictionary<Type, Type> Repositories;

        static RepositoryFactory()
        {
            Repositories = new Dictionary<Type, Type>
                               {
                                   { typeof(CompletedOrder), typeof(CompletedOrderRepository) },
                                   { typeof(Customer), typeof(CustomerRepository) },
                                   { typeof(Lawyer), typeof(LawyerRepository) },
                                   { typeof(Order), typeof(OrderRepository) },
                                   { typeof(Service), typeof(ServiceRepository) },
                                   { typeof(ServicesOfOrder), typeof(ServicesOfOrderRepository) },
                                   { typeof(User), typeof(UserRepository) }
                               };
        }

        public IRepository<T> GetRepository<T>(IDalManager dalManager) where T : DomainObject
        {
            if (Repositories.TryGetValue(typeof(T), out var repositoryType))
            {
                return Activator.CreateInstance(repositoryType, dalManager) as IRepository<T>;
            }

            throw new ArgumentException("Не существует репозитория для заданного доменного объекта.");
        }
    }
}