using System;
using System.Data;
using System.Data.SqlClient;

namespace Client
{
    public class DatabaseManager
    {
        private string connectionString;
        private string sqlQuery;
        private SqlDataAdapter dataAdapter;
        private SqlConnection connection;
        private SqlCommand command;
        private DataSet dataSet;

        public DatabaseManager()
        {
            connectionString = "Data Source=TEMPEST\\SQLEXPRESS;Initial Catalog=Restaurant;Integrated Security=True";
            sqlQuery = string.Empty;
            dataAdapter = new SqlDataAdapter();
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            dataSet = new DataSet();
        }

        public void ActionRows(string sqlQuery)
        {
            try
            {
                connection.Open();
                command.CommandText = sqlQuery;
                command.Connection = connection;
                dataAdapter.SelectCommand = command;

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public DataSet GetRows(string sqlQuery, string dataTableName)
        {
            try
            {
                connection.Open();
                command.CommandText = sqlQuery;
                command.Connection = connection;
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dataSet, dataTableName);
            }
            finally
            {
                connection.Close();
            }

            return dataSet;
        }

        public void ShowAllTest1Elements()
        {
            try
            {
                sqlQuery = "SELECT * FROM test1"; // Remplacez "test1" par le nom de votre table

                connection.Open();
                command.CommandText = sqlQuery;
                command.Connection = connection;
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dataSet, "test1");

                DataTable dataTable = dataSet.Tables["test1"];

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write(row[col] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}