using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Red
{
    public class RedDBProvider
    {
        public string ConnectionString { get; private set; }
        public SqlConnection Connection { get; private set; }

        public RedDBProvider(string conectionString)
        {
            ConnectionString = conectionString;
            Connection = new SqlConnection(ConnectionString);
        }

        public void OpenConnection()
        {
            if(Connection.State!=ConnectionState.Open)
                Connection.Open();
        }

        public void CloseConnection()
        {
            if(Connection.State!=ConnectionState.Closed)
                Connection.Close();
        }

        public DataTable ExecuteSelectCommand(DbCommand command)
        {
            DataTable table;
            try
            {
                OpenConnection();
                DbDataReader reader = command.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return table;
        }

        public int ExecuteNonQueryCommand(DbCommand command)
        {
            int res = 0;
            try
            {
                OpenConnection();
                 res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return res;
        }

        public DataTable ExecuteSelectCommand(string query)
        {
            DbCommand com = new SqlCommand(query,Connection);
            return ExecuteSelectCommand(com);
        }

        public int ExecuteNonQuery(string query)
        {
            DbCommand com = new SqlCommand(query, Connection);
            return ExecuteNonQueryCommand(com);
        }
    }
}