namespace LawFirm.DAL
{
    using System.Collections.Generic;
    using System.Data;

    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class CompletedOrderRepository : IRepository<CompletedOrder>
    {
        private readonly IDalManager dalManager;

        public CompletedOrderRepository(IDalManager dalManager)
        {
            this.dalManager = dalManager;
        }

        public long Insert(CompletedOrder item)
        {
            var query = "INSERT INTO [dbo].[CompletedOrder] ([OrderId], [Expenses]) OUTPUT INSERTED.CompletedOrderId VALUES "
                        + $"('{item.OrderId}', '{item.Expenses}')";
            return this.dalManager.InsertQueryWithOutputInsertedId(query);
        }

        public void InsertById(CompletedOrder item)
        {
            var query = "INSERT INTO [dbo].[CompletedOrder] ([CompletedOrderId], [OrderId], [Expenses]) " + 
                        $"VALUES ({item.CompletedOrderId}, '{item.OrderId}', '{item.Expenses}')";
            this.dalManager.InsertQuery(query);
        }

        public void Update(CompletedOrder item)
        {
            var query = $"UPDATE [dbo].[CompletedOrder] SET [OrderId] = '{item.OrderId}', [Expenses] = '{item.Expenses}' "
                        + $"WHERE [CompletedOrderId] = {item.CompletedOrderId}";
            this.dalManager.UpdateQuery(query);
        }

        public void Delete(long id)
        {
            var query = $"DELETE FROM [dbo].[CompletedOrder] WHERE [CompletedOrderId] = '{id}'";
            this.dalManager.DeleteQuery(query);
        }

        public CompletedOrder SelectById(long id)
        {
            var query = $"SELECT [CompletedOrderId], [OrderId], [Expenses] FROM [dbo].[CompletedOrder] WHERE [CompletedOrderId] = '{id}'";
            var dataTable = this.dalManager.SelectQuery(query);
            return new CompletedOrder
                       {
                           CompletedOrderId =
                               long.Parse(dataTable.Rows[0]["CompletedOrderId"].ToString()),
                           OrderId = long.Parse(dataTable.Rows[0]["OrderId"].ToString()),
                           Expenses = decimal.Parse(dataTable.Rows[0]["Expenses"].ToString())
                       };
        }

        public IEnumerable<CompletedOrder> SelectAll()
        {
            var query = "SELECT [CompletedOrderId], [OrderId], [Expenses] FROM [dbo].[CompletedOrder]";
            var dataTable = this.dalManager.SelectQuery(query);
            var completedOrders = new List<CompletedOrder>();
            foreach (DataRow row in dataTable.Rows)
            {
                completedOrders.Add(new CompletedOrder
                             {
                                 CompletedOrderId =
                                     long.Parse(row["CompletedOrderId"].ToString()),
                                 OrderId = long.Parse(row["OrderId"].ToString()),
                                 Expenses = decimal.Parse(row["Expenses"].ToString())
                             });
            }

            return completedOrders;
        }
    }
}