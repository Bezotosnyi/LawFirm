namespace LawFirm.DAL
{
    using System.Collections.Generic;
    using System.Data;

    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class ServicesOfOrderRepository : IRepository<ServicesOfOrder>
    {
        private readonly IDalManager dalManager;

        public ServicesOfOrderRepository(IDalManager dalManager)
        {
            this.dalManager = dalManager;
        }

        public long Insert(ServicesOfOrder item)
        {
            var query = "INSERT INTO [dbo].[ServicesOfOrder] ([OrderId], [ServiceId]) OUTPUT INSERTED.ServicesOfOrderId VALUES "
                        + $"('{item.OrderId}', '{item.ServiceId}')";
            return this.dalManager.InsertQueryWithOutputInsertedId(query);
        }

        public void InsertById(ServicesOfOrder item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ServicesOfOrder item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public ServicesOfOrder SelectById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServicesOfOrder> SelectAll()
        {
            var query = "SELECT [ServicesOfOrderId], [OrderId], [ServiceId] FROM [dbo].[ServicesOfOrder]";
            var dataTable = this.dalManager.SelectQuery(query);
            var servicesOfOrders = new List<ServicesOfOrder>();
            foreach (DataRow row in dataTable.Rows)
            {
                servicesOfOrders.Add(new ServicesOfOrder
                {
                                            ServicesOfOrderId =
                                                long.Parse(row["ServicesOfOrderId"].ToString()),
                                            OrderId = long.Parse(row["OrderId"].ToString()),
                                            ServiceId = long.Parse(row["ServiceId"].ToString())
                                        });
            }

            return servicesOfOrders;
        }
    }
}