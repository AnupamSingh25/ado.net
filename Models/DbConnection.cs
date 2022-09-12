using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication5.Models
{
    public class DbConnection
    {
        public SqlConnection connection;
        public DbConnection()
        {
            string conn = ConfigurationManager.ConnectionStrings["myconn"].ToString();
            connection = new SqlConnection(conn);
        }
        public DataTable executedatatable(string procname, SqlParameter[] p)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlCommand command = new SqlCommand(procname, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter prm in p)
                {
                    command.Parameters.Add(prm);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dt;
        }
        public DataSet executedataset(string procname, SqlParameter[] p)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand command = new SqlCommand(procname, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter prm in p)
                {
                    command.Parameters.Add(prm);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds;
        }
        public int executenonquery(string procname, SqlParameter[] p)
        {
            SqlCommand command = new SqlCommand(procname, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter per in p)
            {
                command.Parameters.Add(per);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            int res = command.ExecuteNonQuery();
            
            connection.Close();
            return res;

        }
    }
}