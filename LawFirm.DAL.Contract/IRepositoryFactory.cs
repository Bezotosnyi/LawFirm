namespace LawFirm.DAL.Contract
{
    using LawFirm.Domain;

    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>(IDalManager dalManager) where T : DomainObject;
    }
}