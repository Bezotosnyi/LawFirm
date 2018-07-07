namespace LawFirm.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class LawyerRepository : IRepository<Lawyer>
    {
        private readonly IDalManager dalManager;

        public LawyerRepository(IDalManager dalManager)
        {
            this.dalManager = dalManager;
        }

        public long Insert(Lawyer item)
        {
            var query = "INSERT INTO [dbo].[Lawyer] "
                        + "([LastName], [Name], [Patronymic], [Address], [ContactPhone], [ContactPhone2], [HireDate]) OUTPUT INSERTED.LawyerId VALUES "
                        + $"('{item.LastName}', '{item.Name}', '{item.Patronymic}', '{item.Address}', '{item.ContactPhone}', '{item.ContactPhone2}', '{item.HireDate}')";
            return this.dalManager.InsertQueryWithOutputInsertedId(query);
        }

        public void InsertById(Lawyer item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Lawyer item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Lawyer SelectById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Lawyer> SelectAll()
        {
            var query = "SELECT [LawyerId], [LastName], [Name], [Patronymic], [Address], [ContactPhone], [ContactPhone2], [HireDate] FROM [dbo].[Lawyer]";
            var dataTable = this.dalManager.SelectQuery(query);
            var lawyers = new List<Lawyer>();
            foreach (DataRow row in dataTable.Rows)
            {
                lawyers.Add(
                    new Lawyer
                        {
                            LawyerId = long.Parse(row["LawyerId"].ToString()),
                            LastName = row["LastName"].ToString(),
                            Name = row["Name"].ToString(),
                            Patronymic = row["Patronymic"].ToString(),
                            Address = row["Address"].ToString(),
                            ContactPhone = row["ContactPhone"].ToString(),
                            ContactPhone2 = row["ContactPhone2"].ToString(),
                            HireDate = DateTime.Parse(row["HireDate"].ToString())
                        });
            }

            return lawyers;
        }
    }
}