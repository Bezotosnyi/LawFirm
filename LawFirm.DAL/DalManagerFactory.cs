namespace LawFirm.DAL
{
    using LawFirm.DAL.Contract;
    using LawFirm.DAL.MsSqlServer;

    public class DalManagerFactory : IDalManagerFactory
    {
        public IDalManager GetMsSqlServerDalManager()
        {
            return new MsSqlDalManager();
        }

        public IDalManager GetMsSqlServerDalManager(string connectionString)
        {
            return new MsSqlDalManager(connectionString);
        }
    }
}