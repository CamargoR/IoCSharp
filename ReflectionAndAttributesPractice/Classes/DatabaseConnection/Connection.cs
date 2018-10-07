using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Clases
{
    class Connection
    {
        private SqlConnection sqlConnection;

        public Connection(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            sqlConnection.Open();
        }

        public void CloseConnection()
        {
            sqlConnection.Close();
        }

        public void BeginTransaction()
        {
            sqlConnection.BeginTransaction();
        }

        public void testConnection()
        {
            SqlCommand command = new SqlCommand("select 1", sqlConnection);
            OpenConnection();
            command.ExecuteReader();
            CloseConnection();
        }

        public SqlDataReader ExecuteSentence(string sentence) 
        {
            SqlCommand command = new SqlCommand(sentence, sqlConnection);
            SqlDataReader reader;
            OpenConnection();
            reader = command.ExecuteReader();
            return reader;
        }
    }

}
