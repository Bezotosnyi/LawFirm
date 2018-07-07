namespace LawFirm.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class OrderRepository : IRepository<Order>
    {
        private readonly IDalManager dalManager;

        public OrderRepository(IDalManager dalManager)
        {
            this.dalManager = dalManager;
        }

        public long Insert(Order item)
        {
            var query = "INSERT INTO [dbo].[Order] ([DateOfBeginning], [ExpirationDate], [CustomerId], [LawyerId]) OUTPUT INSERTED.OrderId VALUES "
                        + $"('{item.DateOfBeginning}', '{item.ExpirationDate}', '{item.CustomerId}', '{item.LawyerId}')";
            return this.dalManager.InsertQueryWithOutputInsertedId(query);
        }

        public void InsertById(Order item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Order SelectById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> SelectAll()
        {
            var query = "SELECT [OrderId], [DateOfBeginning], [ExpirationDate], [CustomerId], [LawyerId] FROM [dbo].[Order]";
            var dataTable = this.dalManager.SelectQuery(query);
            var orders = new List<Order>();
            foreach (DataRow row in dataTable.Rows)
            {
                var item = new Order
                               {
                                   OrderId = long.Parse(row["OrderId"].ToString()),
                                   DateOfBeginning = DateTime.Parse(row["DateOfBeginning"].ToString()),
                                   ExpirationDate = DateTime.Parse(row["ExpirationDate"].ToString()),
                                   CustomerId = long.Parse(row["CustomerId"].ToString()),
                                   LawyerId = long.Parse(row["LawyerId"].ToString())
                               };
                orders.Add(item);
            }

            return orders;
        }
    }
}