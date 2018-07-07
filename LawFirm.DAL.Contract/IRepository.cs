namespace LawFirm.DAL.Contract
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        long Insert(T item);

        void InsertById(T item);

        void Update(T item);

        void Delete(long id);

        T SelectById(long id);

        IEnumerable<T> SelectAll();
    }
}