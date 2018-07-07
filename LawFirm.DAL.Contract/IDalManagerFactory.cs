namespace LawFirm.DAL.Contract
{
    public interface IDalManagerFactory
    {
        IDalManager GetMsSqlServerDalManager();

        IDalManager GetMsSqlServerDalManager(string connectionString);

        // ...
        // others providers dal manager
    }
}