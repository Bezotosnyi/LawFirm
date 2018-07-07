namespace LawFirm.DAL
{
    using System.Collections.Generic;
    using System.Data;

    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class ServiceRepository : IRepository<Service>
    {
        private readonly IDalManager dalManager;

        public ServiceRepository(IDalManager dalManager)
        {
            this.dalManager = dalManager;
        }

        public long Insert(Service item)
        {
            var query = "INSERT INTO [dbo].[Service] ([Name], [Description], [Cost]) OUTPUT INSERTED.ServiceId VALUES "
                        + $"('{item.Name}', '{item.Description}', '{item.Cost}')";
            return this.dalManager.InsertQueryWithOutputInsertedId(query);
        }

        public void InsertById(Service item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Service item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Service SelectById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Service> SelectAll()
        {
            var query = "SELECT [ServiceId], [Name], [Description], [Cost] FROM [dbo].[Service]";
            var dataTable = this.dalManager.SelectQuery(query);
            var services = new List<Service>();
            foreach (DataRow row in dataTable.Rows)
            {
                var item = new Service
                               {
                                   ServiceId = long.Parse(row["ServiceId"].ToString()),
                                   Name = row["Name"].ToString(),
                                   Description = row["Description"].ToString(),
                                   Cost = decimal.Parse(row["Cost"].ToString())
                               };
                services.Add(item);
            }

            return services;
        }
    }
}