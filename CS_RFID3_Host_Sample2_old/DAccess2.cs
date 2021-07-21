using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace CS_RFID3_Host_Sample2
{
    class DAccess2
    {
        public string connectionString = @"Data Source=RFID-PC;Initial Catalog=trolley;User ID=sa;Password=tiger;";
        int i;
        SqlCommand cmd;
        Connection connection = new Connection();
        public int insert_method(string sqlcmd, Hashtable ht, string sptype)
        {
            try
            {
                cmd = new SqlCommand(sqlcmd);
                if (sptype == "sp")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                cmd.Connection = connection.CreateConnection();
                cmd.CommandTimeout = 1000;

                foreach (DictionaryEntry parameter in ht)
                {
                    cmd.Parameters.Add((string)parameter.Key, parameter.Value);
                }
                i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public int update_method_wo_parameter(string sqlcmd, string sptype)
        {
            try
            {
                cmd = new SqlCommand(sqlcmd);
                if (sptype == "sp")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                cmd.Connection = connection.CreateConnection();
                cmd.CommandTimeout = 1000;

                i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataSet select_method(string sqlcmd, Hashtable ht, string sptype)
        {
            try
            {
                cmd = new SqlCommand(sqlcmd);
                if (sptype == "sp")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                cmd.Connection = connection.CreateConnection();
                cmd.CommandTimeout = 1000;

                foreach (DictionaryEntry parameter in ht)
                {
                    cmd.Parameters.Add((string)parameter.Key, parameter.Value);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataSet select_method_wo_parameter(string sqlcmd, string sptype)
        {
            try
            {
                cmd = new SqlCommand(sqlcmd);
                if (sptype == "sp")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                cmd.Connection = connection.CreateConnection();
                cmd.CommandTimeout = 1000;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataSet SelectQuery(string query)
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);

            return ds;
        }

        public DataSet SelectStoredProcedure(string query)
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);

            return ds;
        }

        public int ExecuteQuery(string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int val = cmd.ExecuteNonQuery();
            con.Close();
            return val;
        }


    }
}