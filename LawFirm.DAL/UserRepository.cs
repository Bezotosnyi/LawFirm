namespace LawFirm.DAL
{
    using System.Collections.Generic;
    using System.Data;

    using LawFirm.DAL.Contract;
    using LawFirm.Domain;

    public class UserRepository : IRepository<User>
    {
        private readonly IDalManager dalManager;

        public UserRepository(IDalManager dalManager)
        {
            this.dalManager = dalManager;
        }

        public long Insert(User item)
        {
            var query = "INSERT INTO [dbo].[User] ([Name], [LastName], [Login], [Password]) OUTPUT INSERTED.UserId VALUES "
                        + $"('{item.Name}', '{item.LastName}', '{item.Login}', '{item.Password}')";
            return this.dalManager.InsertQueryWithOutputInsertedId(query);
        }

        public void InsertById(User item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public User SelectById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> SelectAll()
        {
            var query = "SELECT [UserId], [Name], [LastName], [Login], [Password] FROM [dbo].[User]";
            var dataTable = this.dalManager.SelectQuery(query);
            var users = new List<User>();
            foreach (DataRow row in dataTable.Rows)
            {
                users.Add(new User
                              {
                                  UserId = long.Parse(row["UserId"].ToString()),
                                  Name = row["Name"].ToString(),
                                  LastName = row["LastName"].ToString(),
                                  Login = row["Login"].ToString(),
                                  Password = row["Password"].ToString()
                              });
            }

            return users;
        }
    }
}