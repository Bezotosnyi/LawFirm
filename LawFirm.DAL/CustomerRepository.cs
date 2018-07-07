namespace LawFirm.DAL
{
    using System.Collections.Generic;
    using System.Data;

    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class CustomerRepository : IRepository<Customer>
    {
        private readonly IDalManager dalManager;

        public CustomerRepository(IDalManager dalManager)
        {
            this.dalManager = dalManager;
        }

        public long Insert(Customer item)
        {
            var query = "INSERT INTO [dbo].[Customer] "
                        + "([LastName], [Name], [Patronymic], [Address], [ContactPhone], [ContactPhone2]) OUTPUT INSERTED.CustomerId VALUES "
                        + $"('{item.LastName}', '{item.Name}', '{item.Patronymic}', '{item.Address}', '{item.ContactPhone}', '{item.ContactPhone2}')";
            return this.dalManager.InsertQueryWithOutputInsertedId(query);
        }

        public void InsertById(Customer item)
        {
            var query = "INSERT INTO [dbo].[Customer] "
                        + "([CustomerId], [LastName], [Name], [Patronymic], [Address], [ContactPhone], [ContactPhone2]) VALUES "
                        + $"({item.CustomerId}, '{item.LastName}', '{item.Name}', '{item.Patronymic}', '{item.Address}', "
                        + $"'{item.ContactPhone}', '{item.ContactPhone2}')";
            this.dalManager.InsertQuery(query);
        }

        public void Update(Customer item)
        {
            var query = "UPDATE [dbo].[Customer] SET "
                        + $"[LastName] = '{item.LastName}', [Name] = '{item.Name}', "
                        + $"[Patronymic] = '{item.Patronymic}', [Address] = '{item.Address}', "
                        + $"[ContactPhone] = '{item.ContactPhone}', [ContactPhone2] = '{item.ContactPhone2}' "
                        + $"WHERE [CustomerId] = {item.CustomerId}";
            this.dalManager.UpdateQuery(query);
        }

        public void Delete(long id)
        {
            var query = $"DELETE FROM [dbo].[Customer] WHERE [CustomerId] = '{id}'";
            this.dalManager.DeleteQuery(query);
        }

        public Customer SelectById(long id)
        {
            var query = "SELECT [CustomerId], [LastName], [Name], [Patronymic], [Address], [ContactPhone], [ContactPhone2] "
                        + $"FROM [dbo].[Customer] WHERE [CustomerId] = '{id}'";
            var row = this.dalManager.SelectQuery(query).Rows[0];

            return new Customer
                       {
                           CustomerId = long.Parse(row["CustomerId"].ToString()),
                           LastName = row["LastName"].ToString(),
                           Name = row["Name"].ToString(),
                           Patronymic = row["Patronymic"].ToString(),
                           Address = row["Address"].ToString(),
                           ContactPhone = row["ContactPhone"].ToString(),
                           ContactPhone2 = row["ContactPhone2"].ToString()
                       };
        }

        public IEnumerable<Customer> SelectAll()
        {
            var query = "SELECT [CustomerId], [LastName], [Name], [Patronymic], [Address], [ContactPhone], [ContactPhone2] FROM [dbo].[Customer]";
            var dataTable = this.dalManager.SelectQuery(query);
            var customers = new List<Customer>();
            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(
                    new Customer
                        {
                            CustomerId = long.Parse(row["CustomerId"].ToString()),
                            LastName = row["LastName"].ToString(),
                            Name = row["Name"].ToString(),
                            Patronymic = row["Patronymic"].ToString(),
                            Address = row["Address"].ToString(),
                            ContactPhone = row["ContactPhone"].ToString(),
                            ContactPhone2 = row["ContactPhone2"].ToString()
                        });
            }

            return customers;
        }
    }
}