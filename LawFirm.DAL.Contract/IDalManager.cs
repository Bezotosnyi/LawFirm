namespace LawFirm.DAL.Contract
{
    using System.Data;

    public interface IDalManager
    {
        void InsertQuery(string query);

        long InsertQueryWithOutputInsertedId(string query);

        void UpdateQuery(string query);

        void DeleteQuery(string query);

        DataTable SelectQuery(string query);

        DataTable SelectAllQuery(string query);
    }
}