using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CS_RFID3_Host_Sample2
{
    class Connection
    {
        public SqlConnection con = null;
        public string connectionstring;


        public string connectionString2 = @"Data Source=RFID-PC;Initial Catalog=trolley;User ID=sa;Password=tiger;";
        
        public SqlConnection CreateConnection()
        {
            try
            {

                connectionstring = connectionString2;
                // connectionstring = @"server=DESKTOP-92PG4VS; database=Demo; user id=sa;password=tiger;Pooling=false";
                //connectionstring = @"server=RFID-PC; database=Warehouse; user id=sa;password=tiger;Pooling=false";
                //connectionstring = @"server=DESKTOP-92PG4VS; database=yyyyy; user id=sa;password=tiger;Pooling=false";

                //connectionstring = "server=67.228.73.106; database=ssf; user id=finance;password=ssf!234;Max pool size=1500;Min pool size=20;Pooling=true";
                con = new SqlConnection();
                con.ConnectionString = connectionstring;
                con.Open();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Closed)
                {
                    // connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    // connectionstring = @"server=GREENFUTURZDEMO\SQLEXPRESS; database=Asset; user id=sa;password=tiger;Pooling=false";
                    //  connectionstring = @"server=HS-9CB6548D25B4; database=yyyyy; user id=sa;password=RFID@123;Pooling=false";
                    connectionstring = connectionString2;
                    //    connectionstring = @"server=DESKTOP-92PG4VS; database=yyyyy; user id=sa;password=tiger;Pooling=false";
                    ///      connectionstring = @"server=DESKTOP-92PG4VS; database=Demo; user id=sa;password=tiger;Pooling=false";

                    //connectionstring = @"server=DESKTOP-92PG4VS; database=test; user id=sa;password=tiger;Pooling=false";

                    //connectionstring = "server=67.228.73.106; database=ssf; user id=finance;password=ssf!234;Pooling=false";
                    con = new SqlConnection();
                    con.ConnectionString = connectionstring;
                    con.Open();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    //connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    // connectionstring = @"server=GREENFUTURZDEMO\SQLEXPRESS; database=Asset; user id=sa;password=tiger;Pooling=false";
                    //connectionstring = @"server=DESKTOP-92PG4VS; database=mainetti; user id=sa;password=tiger;Pooling=false";
                    connectionstring = connectionString2;
                    // connectionstring = @"server=HS-9CB6548D25B4; database=yyyyy; user id=sa;password=RFID@123;Pooling=false";
                    //connectionstring = @"server=DESKTOP-92PG4VS; database=Demo; user id=sa;password=tiger;Pooling=false";
                    //connectionstring = @"server=DESKTOP-92PG4VS; database=test; user id=sa;password=tiger;Pooling=false";
                    con = new SqlConnection();
                    con.ConnectionString = connectionstring;
                    con.Open();
                }
                Console.WriteLine(ex.Message);
            }
            return con;
        }

        public SqlConnection LocalCreateConnection()
        {
            try
            {
                /// connectionstring = @"server=DESKTOP-92PG4VS; database=Demo; user id=sa;password=tiger;Pooling=false";
                //connectionstring = @"server=GREENFUTURZDEMO\SQLEXPRESSS; database=Asset; user id=sa;password=tiger;Pooling=false";
                connectionstring = connectionString2;
                //connectionstring = @"server=HS-9CB6548D25B4; database=yyyyy; user id=sa;password=RFID@123;Pooling=false";
                //connectionstring = @"server=TRV-PC-RFIDS\SQLEXPRESS; database=Asset; user id=sa;password=Password@1;Pooling=false";
                // connectionstring = @"server=DESKTOP-92PG4VS; database=test; user id=sa;password=tiger;Pooling=false";
                con = new SqlConnection();
                con.ConnectionString = connectionstring;
                con.Open();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Closed)
                {
                    string connectionstring = "Server=localhost; database=ssf;Integrated Security=True; uid=sa;pwd=sa;";
                    con = new SqlConnection();
                    con.ConnectionString = connectionstring;
                    con.Open();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    string connectionstring = "Server=localhost; database=ssf;Integrated Security=True; uid=sa;pwd=sa;";
                    con = new SqlConnection();
                    con.ConnectionString = connectionstring;
                    con.Open();
                }
                Console.WriteLine(ex.Message);
            }
            return con;
        }

        public void Close()
        {
            con.Close();
        }

        public bool IsConnected()
        {
            System.Uri Url = new System.Uri("http://www.yahoo.com");

            System.Net.WebRequest WebReq;
            System.Net.WebResponse Resp;
            WebReq = System.Net.WebRequest.Create(Url);

            try
            {
                Resp = WebReq.GetResponse();
                Resp.Close();
                WebReq = null;
                return true;
            }

            catch
            {
                WebReq = null;
                return false;
            }
        }
    }
}