namespace LawFirm.DAL.MsSqlServer
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    using LawFirm.DAL.Contract;

    public class MsSqlDalManager : IDalManager
    {
        private readonly string connectionString;

        public MsSqlDalManager()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MsSqlServerConnectionString"].ConnectionString;
        }

        public MsSqlDalManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertQuery(string query)
        {
            using (var connection = new SqlConnection(this.connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public long InsertQueryWithOutputInsertedId(string query)
        {
            long insertedId;

            using (var connection = new SqlConnection(this.connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                insertedId = (long)command.ExecuteScalar();
                connection.Close();
            }

            return insertedId;
        }

        public void UpdateQuery(string query)
        {
            using (var connection = new SqlConnection(this.connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteQuery(string query)
        {
            using (var connection = new SqlConnection(this.connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public DataTable SelectQuery(string query)
        {
            DataTable dataTable;
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(this.connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
                connection.Close();
            }

            return dataTable;
        }

        public DataTable SelectAllQuery(string query)
        {
            DataTable dataTable;
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(this.connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
                connection.Close();
            }

            return dataTable;
        }
    }
}