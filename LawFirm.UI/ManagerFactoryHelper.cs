namespace LawFirm.UI
{
    using LawFirm.BLL;
    using LawFirm.BLL.Contract;
    using LawFirm.DAL;
    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public static class ManagerFactoryHelper
    {
        private static readonly IDalManagerFactory DalManagerFactory;

        private static readonly IRepositoryFactory RepositoryFactory;

        static ManagerFactoryHelper()
        {
            DalManagerFactory = new DalManagerFactory();
            RepositoryFactory = new RepositoryFactory();
        }

        public static ICompletedOrderManager GetCompletedOrderManager()
        {
            return new CompletedOrderManager(RepositoryFactory.GetRepository<CompletedOrder>(DalManagerFactory.GetMsSqlServerDalManager()));
        }

        public static ICustomerManager GetCustomerManager()
        {
            return new CustomerManager(RepositoryFactory.GetRepository<Customer>(DalManagerFactory.GetMsSqlServerDalManager()));
        }

        public static ILawyerManager GetLawyerManager()
        {
            return new LawyerManager(RepositoryFactory.GetRepository<Lawyer>(DalManagerFactory.GetMsSqlServerDalManager()));
        }

        public static IOrderManager GetOrderManager()
        {
            return new OrderManager(
                RepositoryFactory.GetRepository<Order>(DalManagerFactory.GetMsSqlServerDalManager()),
                RepositoryFactory.GetRepository<ServicesOfOrder>(DalManagerFactory.GetMsSqlServerDalManager()),
                RepositoryFactory.GetRepository<Customer>(DalManagerFactory.GetMsSqlServerDalManager()),
                RepositoryFactory.GetRepository<Lawyer>(DalManagerFactory.GetMsSqlServerDalManager()),
                RepositoryFactory.GetRepository<Service>(DalManagerFactory.GetMsSqlServerDalManager()));
        }

        public static IReportManager GetReportManager()
        {
            return new ReportManager(GetCompletedOrderManager(), GetOrderManager());
        }

        public static ISelectionManager GetSelectionManager()
        {
            return new SelectionManager(GetOrderManager());
        }

        public static IServiceManager GetServiceManager()
        {
            return new ServiceManager(RepositoryFactory.GetRepository<Service>(DalManagerFactory.GetMsSqlServerDalManager()));
        }

        public static IUserManager GetUserManager()
        {
            return new UserManager(RepositoryFactory.GetRepository<User>(DalManagerFactory.GetMsSqlServerDalManager()));
        }
    }
}