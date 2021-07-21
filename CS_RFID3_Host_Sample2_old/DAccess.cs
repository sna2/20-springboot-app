using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public class DAccess
{
    int i;
    SqlCommand cmd;
    DBConnection connection = new DBConnection();
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
            cmd.Connection = DBConnection.CreateConnection();
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
            DBConnection.Close();
        }
    }

    public int Insert_Method(string splcmd, Hashtable hat, string sptype)
    {
        try
        {
            cmd = new SqlCommand(splcmd);
            if (sptype == "sp")
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }
            cmd.Connection = DBConnection.CreateConnection();
            cmd.CommandTimeout = 1000;

            foreach (DictionaryEntry parameter in hat)
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
            DBConnection.Close();
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
            cmd.Connection = DBConnection.CreateConnection();
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
            DBConnection.Close();
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
            cmd.Connection = DBConnection.CreateConnection();
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
            DBConnection.Close();
        }
    }

    public DataTable select_method_wo_parameter1(string sqlcmd, string sptype)
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
            cmd.Connection = DBConnection.CreateConnection();
            cmd.CommandTimeout = 1000;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            DBConnection.Close();
        }
    }

    public int DatabaseBackup(string backupPath)
    {
        int retVal = 0;

        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        //SqlCommand cmd = new SqlCommand();
        cmd = new SqlCommand();
        cmd.CommandText = @"Backup Database To Disk = '" + backupPath + "' WITH INIT";
        cmd.CommandType = CommandType.Text;
       
        try
        {
            cmd.Connection = DBConnection.CreateConnection();
            //conn.Open();
            //cmd.Connection = conn;
            retVal = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        finally
        {
            DBConnection.Close();
        }

        return retVal;
    }
}
