using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading;
using CS_RFID3_Host_Sample2;

namespace CS_RFID3_Host_Sample2
{
    public partial class NewItem : Form
    {
        SqlConnection con = new SqlConnection("Data Source=103.14.120.46;Initial Catalog=trolley;User ID=sa;Password=tiger@1234");
        DAccess2 db = new DAccess2();
        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        SqlDataAdapter da;
        public NewItem()
        {
            InitializeComponent();
            Auto();
            //using (SqlConnection con = new SqlConnection(ConString))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT Item_code FROM Itemmaster", con);
            //    con.Open();
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            //    while (reader.Read())
            //    {
            //        MyCollection.Add(reader.GetString(0));
            //    }
            //    textBox1.AutoCompleteCustomSource = MyCollection;
            //    con.Close();
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Auto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //calling the auto method.  
        }
        //Main logic for autocomplete   
        public void Auto()
        {

            da = new SqlDataAdapter("SELECT Item_code FROM Itemmaster", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    coll.Add(dt.Rows[i]["Item_code"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Item Code not found");
            }
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = coll;
            fillgrid();
        }

        public void fillgrid()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = db.SelectQuery("select Description from Itemmaster where Item_code='" + textBox1.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox2.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                fillgrid(); //when selecting the searched name then filling its data in datagrid.    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged3(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TmpSerialNo;
            string TmpSerialNo1;
            string TmpSerialNo11;
            string TmpSerialNo12;
            string TmpL1;
            string TmpL2;
            string TmpL3;
            string TmpL4;
            string TmpL5;
            string TmpL6;
            string TmpL7;
            string TmpL8;
            string TmpL9;
            string TmpL10;
            string TmpL20;
            string TmpL21;
            string TmpL22;
            string TmpL23;
            string TmpL24;
            string TmpL25;
            string TmpL26;
            string TmpL27;
            string TmpL28;
            string TmpL29;            
            string TmpL101;                      
            string TmpL104;
            string data,data1,data2,data3,data4,data5;
             

            DataSet ds = new DataSet();
            ds = db.SelectQuery("select Description from Itemmaster where Item_code='" + textBox1.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DialogResult result1 = MessageBox.Show("Are you sure have added all Cartons to the pallet ? Do you want to go ahead with printing the label ?", "Important Question", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    int count = Convert.ToInt32(textBox4.Text);
                    string datetim = DateTime.Now.ToString("ddMMyy");
                    DataSet ds1 = new DataSet();
                    DataSet ds2 = new DataSet();
                    ds2 = db.SelectQuery("select PAlletid from printrfid order by PAlletid desc ");                   
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            int PAlletid = Convert.ToInt32(ds2.Tables[0].Rows[0]["PAlletid"].ToString());
                            PAlletid = PAlletid + 1;
                            for (int i = 0; count > i; i++)
                            {
                                ds1 = db.SelectQuery("select BatchNo from printrfid where Convert(date,printerDate)=CONVERT(date,Getdate()) order by Batchno desc ");
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    string BatchNo = ds1.Tables[0].Rows[0]["BatchNo"].ToString();
                                    int Batch = Convert.ToInt32(BatchNo);
                                    int das = Convert.ToInt32(Batch + 1);
                                    string das1 = Convert.ToString(das);
                                    int count1 = das1.Length;
                                    if (count1 > 7)
                                    {
                                        int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                                 " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + das + "','" + PAlletid + "')");
                                        if (vl > 0)
                                        {
                                        }
                                    }
                                    else
                                    {
                                        string das2 = "0" + das1;
                                        int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                                " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + das2 + "','" + PAlletid + "')");
                                        if (vl > 0)
                                        {
                                        }
                                        //{
                                        //    string query = "select itemcode,Is_active,sno from printrfid where Is_active=0";
                                        //    DataSet dsda = db.SelectQuery(query);
                                        //    DataTable dt = dsda.Tables[0];
                                        //    int k = 0;
                                        //    if (dsda.Tables[0].Rows.Count > 0)
                                        //    {
                                        //        //string snos = dsda.Tables[0].Rows[0]["sno"].ToString();
                                        //        int datacount = dsda.Tables[0].Rows.Count;
                                        //        int palletcount = datacount + 1;
                                        //        foreach (DataRow dr in dt.Rows)
                                        //        {
                                        //            if (dr["Is_active"].ToString() != "False")
                                        //            {

                                        //            }
                                        //            else
                                        //            {
                                        //                if (k != palletcount)
                                        //                {
                                        //                    Thread.Sleep(5000);
                                        //                    //string printerrfid = dr["printerRfidID"].ToString();
                                        //                    string Itemcodes = dr["Itemcode"].ToString();
                                        //                    string snos = dr["sno"].ToString();
                                        //                    string fileLoca = @"D:\test\testingdata.txt";
                                        //                    // string fileLoc = @"E:\test\sample1.txt";
                                        //                    if (File.Exists(fileLoca))
                                        //                    {
                                        //                        using (StreamWriter sw = new StreamWriter(fileLoca))
                                        //                        {
                                        //                            TmpSerialNo = "^XA";
                                        //                            TmpSerialNo1 = "^PW559";
                                        //                            TmpL1 = "^FO10,90";
                                        //                            TmpL2 = "^FN0";
                                        //                            TmpL3 = "^FS";
                                        //                            TmpL4 = "^FN0";
                                        //                            TmpL5 = "^RFR,H";
                                        //                            TmpL6 = "^FS";
                                        //                            TmpL7 = "^FT300,120^BQN,2,2";
                                        //                            TmpL8 = "^FH\\^FDLA,Item Code-" + textBox1.Text + "";
                                        //                            TmpL9 = "FH\\^FDLA,RFR,H^FS";
                                        //                            TmpL10 = "FT40,70^A0N,25,25^FH\\^FDItem Code-" + textBox1.Text + "\\RFR,H^FS";
                                        //                            TmpL101 = "^XZ";

                                        //                            sw.WriteLine(TmpSerialNo);
                                        //                            sw.WriteLine(TmpSerialNo1);
                                        //                            sw.WriteLine(TmpL1);
                                        //                            sw.WriteLine(TmpL2);
                                        //                            sw.WriteLine(TmpL3);
                                        //                            sw.WriteLine(TmpL4);
                                        //                            sw.WriteLine(TmpL5);
                                        //                            sw.WriteLine(TmpL6);
                                        //                            sw.WriteLine(TmpL7);
                                        //                            sw.WriteLine(TmpL8);
                                        //                            sw.WriteLine(TmpL9);
                                        //                            sw.WriteLine(TmpL10);
                                        //                            sw.WriteLine(TmpL101);

                                        //                            ProcessStartInfo psi = new ProcessStartInfo(("D:\\test\\BatchPrn2.bat"));
                                        //                            Process process = Process.Start(psi);


                                        //                            dr["Is_active"] = "True";
                                        //                            //ds.Tables[0].Rows[0]["Is_active"] = "True";

                                        //                            // string fileLoc = @"E:\test\sample1.txt";


                                        //                            // string arye = "update printrfid Set Is_active=1 where printerrfidID= '" + printerrfid + "'";
                                        //                            // int v = db.ExecuteQuery(arye);
                                        //                            i = i + 1;

                                        //                        }
                                        //                    }
                                        //                    string fileName = @"D:\test\testingdata.txt";
                                        //                    var lines = File.ReadAllLines(fileName);
                                        //                    for (var dd = 0; dd < lines.Length; dd += 1)
                                        //                    {
                                        //                        string line = lines[0];
                                        //                        string line1 = lines[1];
                                        //                        string line2 = lines[2];
                                        //                        string line3 = lines[3];
                                        //                        string line4 = lines[4];
                                        //                        string line5 = lines[5];
                                        //                        string line6 = lines[6];
                                        //                        string line7 = lines[7];
                                        //                        string line8 = lines[8];
                                        //                        string line9 = lines[9];
                                        //                        string line10 = lines[10];
                                        //                        string line11 = lines[11];
                                        //                        string line12 = lines[12];


                                        //                        string Palletid = line10;


                                        //                        int values = db.ExecuteQuery(" update printrfid set printerrfidid='" + line10 + "',Is_active=1 where sno='" + snos + "'");

                                        //                        if (values > 0)
                                        //                        {

                                        //                        }
                                        //                        // Process line
                                        //                    }

                                        //                }
                                        //                else
                                        //                {
                                        //                    //Thread.Sleep(5000);                            
                                        //                }
                                        //            }
                                        //        }
                                        //        if (palletcount == datacount)
                                        //        {
                                        //            string fileLoc = @"D:\test\testingdata.txt";
                                        //            // string fileLoc = @"E:\test\sample1.txt";
                                        //            if (File.Exists(fileLoc))
                                        //            {
                                        //                using (StreamWriter sw1 = new StreamWriter(fileLoc))
                                        //                {
                                        //                    TmpSerialNo11 = "^XA";
                                        //                    TmpSerialNo12 = "^PW559";
                                        //                    TmpL21 = "^FO10,90";
                                        //                    TmpL22 = "^FN0";
                                        //                    TmpL23 = "^FS";
                                        //                    TmpL24 = "^FN0";
                                        //                    TmpL25 = "^RFR,H";
                                        //                    TmpL26 = "^FS";
                                        //                    TmpL27 = "^FT300,120^BQN,2,2";
                                        //                    TmpL28 = "^FH\\^FDLA,Item Code-" + textBox1.Text + "";
                                        //                    TmpL29 = "FH\\^FDLA,RFR,H^FS";
                                        //                    TmpL20 = "FT40,70^A0N,25,25^FH\\^FDItem Code-" + textBox1.Text + "\\RFR,H^FS";
                                        //                    TmpL104 = "^XZ";

                                        //                    sw1.WriteLine(TmpSerialNo11);
                                        //                    sw1.WriteLine(TmpSerialNo12);
                                        //                    sw1.WriteLine(TmpL21);
                                        //                    sw1.WriteLine(TmpL22);
                                        //                    sw1.WriteLine(TmpL23);
                                        //                    sw1.WriteLine(TmpL24);
                                        //                    sw1.WriteLine(TmpL25);
                                        //                    sw1.WriteLine(TmpL26);
                                        //                    sw1.WriteLine(TmpL27);
                                        //                    sw1.WriteLine(TmpL28);
                                        //                    sw1.WriteLine(TmpL29);
                                        //                    sw1.WriteLine(TmpL20);
                                        //                    sw1.WriteLine(TmpL104);

                                        //                    ProcessStartInfo psi1 = new ProcessStartInfo(("D:\\test\\BatchPrn2.bat"));
                                        //                    Process process1 = Process.Start(psi1);





                                                            
                                        //                    ////ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Printing Complete ... ');", true);
                                        //                    ////GridLoad();
                                        //                }

                                        //                string fileName = @"D:\test\testingdata.txt";
                                        //                var lines = File.ReadAllLines(fileName);
                                        //                for (var dd = 0; dd < lines.Length; dd += 1)
                                        //                {
                                        //                    string line = lines[0];
                                        //                    string line1 = lines[1];
                                        //                    string line2 = lines[2];
                                        //                    string line3 = lines[3];
                                        //                    string line4 = lines[4];
                                        //                    string line5 = lines[5];
                                        //                    string line6 = lines[6];
                                        //                    string line7 = lines[7];
                                        //                    string line8 = lines[8];
                                        //                    string line9 = lines[9];
                                        //                    string line10 = lines[10];
                                        //                    string line11 = lines[11];
                                        //                    string line12 = lines[12];

                                        //                    string Palletid = line10;

                                        //                    int values = db.ExecuteQuery(" update printrfid set palletrfid='" + line10 + "',flg=1 where flg=0");

                                        //                    if (values > 0)
                                        //                    {

                                        //                    }
                                        //                    // Process line
                                        //                }
                                        //            }
                                        //        }
                                        //    }
                                        //}
                                    }
                                }
                                else
                                {
                                    PAlletid = PAlletid + 1;
                                    string time = "01";
                                    string datetime = datetim + "" + time;
                                    int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                             " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + datetime + "','" + PAlletid + "')");
                                    if (vl > 0)
                                    {
                                    }
                                }
                            }
                        }
                        else
                        {
                            int PAlletid = 1;
                           // PAlletid = PAlletid + 1;
                            for (int i = 0; count > i; i++)
                            {
                                ds1 = db.SelectQuery("select BatchNo from printrfid where Convert(date,printerDate)=CONVERT(date,Getdate()) order by Batchno desc ");
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    string BatchNo = ds1.Tables[0].Rows[0]["BatchNo"].ToString();
                                    int Batch = Convert.ToInt32(BatchNo);
                                    int das = Convert.ToInt32(Batch + 1);
                                    string das1 = Convert.ToString(das);
                                    int count1 = das1.Length;
                                    if (count1 > 7)
                                    {
                                        int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                                 " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + das + "','" + PAlletid + "')");
                                        if (vl > 0)
                                        {
                                        //    string query = "select itemcode,Is_active,sno from printrfid where Is_active=0";
                                        //    DataSet dsda = db.SelectQuery(query);
                                        //    DataTable dt = dsda.Tables[0];
                                        //    int k = 0;
                                        //    if (dsda.Tables[0].Rows.Count > 0)
                                        //    {
                                        //        //string snos = dsda.Tables[0].Rows[0]["sno"].ToString();
                                        //        int datacount = dsda.Tables[0].Rows.Count;
                                        //        int palletcount = datacount + 1;
                                        //        foreach (DataRow dr in dt.Rows)
                                        //        {
                                        //            if (dr["Is_active"].ToString() != "False")
                                        //            {

                                        //            }
                                        //            else
                                        //            {
                                        //                if (k != palletcount)
                                        //                {
                                        //                    Thread.Sleep(5000);
                                        //                    //string printerrfid = dr["printerRfidID"].ToString();
                                        //                    string Itemcodes = dr["Itemcode"].ToString();
                                        //                    string snos = dr["sno"].ToString();
                                        //                    string fileLoca = @"D:\test\testingdata.txt";
                                        //                    // string fileLoc = @"E:\test\sample1.txt";
                                        //                    if (File.Exists(fileLoca))
                                        //                    {
                                        //                        using (StreamWriter sw = new StreamWriter(fileLoca))
                                        //                        {
                                        //                            TmpSerialNo = "^XA";
                                        //                            TmpSerialNo1 = "^PW559";
                                        //                            TmpL1 = "^FO10,90";
                                        //                            TmpL2 = "^FN0";
                                        //                            TmpL3 = "^FS";
                                        //                            TmpL4 = "^FN0";
                                        //                            TmpL5 = "^RFR,H";
                                        //                            TmpL6 = "^FS";
                                        //                            TmpL7 = "^FT300,120^BQN,2,2";
                                        //                            TmpL8 = "^FH\\^FDLA,Item Code-" + textBox1.Text + "";
                                        //                            TmpL9 = "FH\\^FDLA,RFR,H^FS";
                                        //                            TmpL10 = "FT40,70^A0N,25,25^FH\\^FDItem Code-" + textBox1.Text + "\\RFR,H^FS";
                                        //                            TmpL101 = "^XZ";

                                        //                            sw.WriteLine(TmpSerialNo);
                                        //                            sw.WriteLine(TmpSerialNo1);
                                        //                            sw.WriteLine(TmpL1);
                                        //                            sw.WriteLine(TmpL2);
                                        //                            sw.WriteLine(TmpL3);
                                        //                            sw.WriteLine(TmpL4);
                                        //                            sw.WriteLine(TmpL5);
                                        //                            sw.WriteLine(TmpL6);
                                        //                            sw.WriteLine(TmpL7);
                                        //                            sw.WriteLine(TmpL8);
                                        //                            sw.WriteLine(TmpL9);
                                        //                            sw.WriteLine(TmpL10);
                                        //                            sw.WriteLine(TmpL101);

                                        //                            ProcessStartInfo psi = new ProcessStartInfo(("D:\\test\\BatchPrn2.bat"));
                                        //                            Process process = Process.Start(psi);

                                        //                            dr["Is_active"] = "True";

                                        //                            // string fileLoc = @"E:\test\sample1.txt";


                                        //                            // string arye = "update printrfid Set Is_active=1 where printerrfidID= '" + printerrfid + "'";
                                        //                            // int v = db.ExecuteQuery(arye);
                                        //                            i = i + 1;

                                        //                        }
                                        //                    }
                                        //                    string fileName = @"D:\test\testingdata.txt";
                                        //                    var lines = File.ReadAllLines(fileName);
                                        //                    for (var dd = 0; dd < lines.Length; dd += 1)
                                        //                    {
                                        //                        string line = lines[0];
                                        //                        string line1 = lines[1];
                                        //                        string line2 = lines[2];
                                        //                        string line3 = lines[3];
                                        //                        string line4 = lines[4];
                                        //                        string line5 = lines[5];
                                        //                        string line6 = lines[6];
                                        //                        string line7 = lines[7];
                                        //                        string line8 = lines[8];
                                        //                        string line9 = lines[9];
                                        //                        string line10 = lines[10];
                                        //                        string line11 = lines[11];
                                        //                        string line12 = lines[12];

                                        //                        string Palletid = line10;

                                        //                        int values = db.ExecuteQuery(" update printrfid set printerrfidid='" + line10 + "',Is_active=1 where sno='" + snos + "'");

                                        //                        if (values > 0)
                                        //                        {

                                        //                        }

                                        //                        // Process line
                                        //                    }
                                        //                }
                                        //                else
                                        //                {
                                        //                    //Thread.Sleep(5000);                            
                                        //                }
                                        //            }
                                        //        }
                                        //        if (palletcount == datacount)
                                        //        {
                                        //            string fileLoc = @"D:\test\testingdata.txt";
                                        //            // string fileLoc = @"E:\test\sample1.txt";
                                        //            if (File.Exists(fileLoc))
                                        //            {
                                        //                using (StreamWriter sw1 = new StreamWriter(fileLoc))
                                        //                {
                                        //                    TmpSerialNo11 = "^XA";
                                        //                    TmpSerialNo12 = "^PW559";
                                        //                    TmpL21 = "^FO10,90";
                                        //                    TmpL22 = "^FN0";
                                        //                    TmpL23 = "^FS";
                                        //                    TmpL24 = "^FN0";
                                        //                    TmpL25 = "^RFR,H";
                                        //                    TmpL26 = "^FS";
                                        //                    TmpL27 = "^FT300,120^BQN,2,2";
                                        //                    TmpL28 = "^FH\\^FDLA,Item Code-" + textBox1.Text + "";
                                        //                    TmpL29 = "FH\\^FDLA,RFR,H^FS";
                                        //                    TmpL20 = "FT40,70^A0N,25,25^FH\\^FDItem Code-" + textBox1.Text + "\\RFR,H^FS";
                                        //                    TmpL104 = "^XZ";

                                        //                    sw1.WriteLine(TmpSerialNo11);
                                        //                    sw1.WriteLine(TmpSerialNo12);
                                        //                    sw1.WriteLine(TmpL21);
                                        //                    sw1.WriteLine(TmpL22);
                                        //                    sw1.WriteLine(TmpL23);
                                        //                    sw1.WriteLine(TmpL24);
                                        //                    sw1.WriteLine(TmpL25);
                                        //                    sw1.WriteLine(TmpL26);
                                        //                    sw1.WriteLine(TmpL27);
                                        //                    sw1.WriteLine(TmpL28);
                                        //                    sw1.WriteLine(TmpL29);
                                        //                    sw1.WriteLine(TmpL20);
                                        //                    sw1.WriteLine(TmpL104);

                                        //                    ProcessStartInfo psi1 = new ProcessStartInfo(("D:\\test\\BatchPrn2.bat"));
                                        //                    Process process1 = Process.Start(psi1);

                                                           
                                        //                    ////ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Printing Complete ... ');", true);
                                        //                    ////GridLoad();
                                        //                }

                                        //                string fileName = @"D:\test\testingdata.txt";
                                        //                var lines = File.ReadAllLines(fileName);
                                        //                for (var dd = 0; dd < lines.Length; dd += 1)
                                        //                {
                                        //                    string line = lines[0];
                                        //                    string line1 = lines[1];
                                        //                    string line2 = lines[2];
                                        //                    string line3 = lines[3];
                                        //                    string line4 = lines[4];
                                        //                    string line5 = lines[5];
                                        //                    string line6 = lines[6];
                                        //                    string line7 = lines[7];
                                        //                    string line8 = lines[8];
                                        //                    string line9 = lines[9];
                                        //                    string line10 = lines[10];
                                        //                    string line11 = lines[11];
                                        //                    string line12 = lines[12];

                                        //                    string Palletid = line10;

                                        //                    int values = db.ExecuteQuery(" update printrfid set palletrfid='" + line10 + "',flg=1 where flg=0");

                                        //                    if (values > 0)
                                        //                    {

                                        //                    }

                                        //                    // Process line
                                        //                }
                                        //            }
                                        //        }
                                        //    }
                                        }
                                    }
                                    else
                                    {
                                        string das2 = "0" + das1;
                                        int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                                " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + das2 + "','" + PAlletid + "')");
                                        if (vl > 0)
                                        {
                                        //    string query = "select itemcode,Is_active,sno from printrfid where Is_active=0";
                                        //    DataSet dsda = db.SelectQuery(query);
                                        //    DataTable dt = dsda.Tables[0];
                                        //    int k = 0;
                                        //    if (dsda.Tables[0].Rows.Count > 0)
                                        //    {
                                        //       // string snos = dsda.Tables[0].Rows[0]["sno"].ToString();
                                        //        int datacount = dsda.Tables[0].Rows.Count;
                                        //        int palletcount = datacount + 1;
                                        //        foreach (DataRow dr in dt.Rows)
                                        //        {
                                        //            if (dr["Is_active"].ToString() != "False")
                                        //            {

                                        //            }
                                        //            else
                                        //            {
                                        //                if (k != palletcount)
                                        //                {
                                        //                    Thread.Sleep(5000);
                                        //                    //string printerrfid = dr["printerRfidID"].ToString();
                                        //                    string Itemcodes = dr["Itemcode"].ToString();
                                        //                    string snos = dr["sno"].ToString();
                                        //                    string fileLoca = @"D:\test\testingdata.txt";
                                        //                    // string fileLoc = @"E:\test\sample1.txt";
                                        //                    if (File.Exists(fileLoca))
                                        //                    {
                                        //                        using (StreamWriter sw = new StreamWriter(fileLoca))
                                        //                        {
                                        //                            TmpSerialNo = "^XA";
                                        //                            TmpSerialNo1 = "^PW559";
                                        //                            TmpL1 = "^FO10,90";
                                        //                            TmpL2 = "^FN0";
                                        //                            TmpL3 = "^FS";
                                        //                            TmpL4 = "^FN0";
                                        //                            TmpL5 = "^RFR,H";
                                        //                            TmpL6 = "^FS";
                                        //                            TmpL7 = "^FT300,120^BQN,2,2";
                                        //                            TmpL8 = "^FH\\^FDLA,Item Code-" + textBox1.Text + "";
                                        //                            TmpL9 = "FH\\^FDLA,RFR,H^FS";
                                        //                            TmpL10 = "FT40,70^A0N,25,25^FH\\^FDItem Code-" + textBox1.Text + "\\RFR,H^FS";
                                        //                            TmpL101 = "^XZ";

                                        //                            sw.WriteLine(TmpSerialNo);
                                        //                            sw.WriteLine(TmpSerialNo1);
                                        //                            sw.WriteLine(TmpL1);
                                        //                            sw.WriteLine(TmpL2);
                                        //                            sw.WriteLine(TmpL3);
                                        //                            sw.WriteLine(TmpL4);
                                        //                            sw.WriteLine(TmpL5);
                                        //                            sw.WriteLine(TmpL6);
                                        //                            sw.WriteLine(TmpL7);
                                        //                            sw.WriteLine(TmpL8);
                                        //                            sw.WriteLine(TmpL9);
                                        //                            sw.WriteLine(TmpL10);
                                        //                            sw.WriteLine(TmpL101);

                                        //                            ProcessStartInfo psi = new ProcessStartInfo(("D:\\test\\BatchPrn2.bat"));
                                        //                            Process process = Process.Start(psi);


                                        //                            dr["Is_active"] = "True";
                                        //                            //ds.Tables[0].Rows[0]["Is_active"] = "True";

                                        //                            // string fileLoc = @"E:\test\sample1.txt";


                                        //                            // string arye = "update printrfid Set Is_active=1 where printerrfidID= '" + printerrfid + "'";
                                        //                            // int v = db.ExecuteQuery(arye);
                                        //                            i = i + 1;

                                        //                        }
                                        //                    }
                                        //                    string fileName = @"D:\test\testingdata.txt";
                                        //                    var lines = File.ReadAllLines(fileName);
                                        //                    for (var dd = 0; dd < lines.Length; dd += 1)
                                        //                    {
                                        //                        string line = lines[0];
                                        //                        string line1 = lines[1];
                                        //                        string line2 = lines[2];
                                        //                        string line3 = lines[3];
                                        //                        string line4 = lines[4];
                                        //                        string line5 = lines[5];
                                        //                        string line6 = lines[6];
                                        //                        string line7 = lines[7];
                                        //                        string line8 = lines[8];
                                        //                        string line9 = lines[9];
                                        //                        string line10 = lines[10];
                                        //                        string line11 = lines[11];
                                        //                        string line12 = lines[12];


                                        //                        string Palletid = line10;


                                        //                        int values = db.ExecuteQuery(" update printrfid set printerrfidid='" + line10 + "' where sno='" + snos + "'");

                                        //                        if (values > 0)
                                        //                        {

                                        //                        }



                                        //                        // Process line
                                        //                    }

                                        //                }
                                        //                else
                                        //                {
                                        //                    //Thread.Sleep(5000);                            
                                        //                }
                                        //            }
                                        //        }
                                        //        if (palletcount == datacount+1)
                                        //        {
                                        //            string fileLoc = @"D:\test\testingdata.txt";
                                        //            // string fileLoc = @"E:\test\sample1.txt";
                                        //            if (File.Exists(fileLoc))
                                        //            {
                                        //                using (StreamWriter sw1 = new StreamWriter(fileLoc))
                                        //                {
                                        //                    TmpSerialNo11 = "^XA";
                                        //                    TmpSerialNo12 = "^PW559";
                                        //                    TmpL21 = "^FO10,90";
                                        //                    TmpL22 = "^FN0";
                                        //                    TmpL23 = "^FS";
                                        //                    TmpL24 = "^FN0";
                                        //                    TmpL25 = "^RFR,H";
                                        //                    TmpL26 = "^FS";
                                        //                    TmpL27 = "^FT300,120^BQN,2,2";
                                        //                    TmpL28 = "^FH\\^FDLA,Item Code-" + textBox1.Text + "";
                                        //                    TmpL29 = "FH\\^FDLA,RFR,H^FS";
                                        //                    TmpL20 = "FT40,70^A0N,25,25^FH\\^FDItem Code-" + textBox1.Text + "\\RFR,H^FS";
                                        //                    TmpL104 = "^XZ";

                                        //                    sw1.WriteLine(TmpSerialNo11);
                                        //                    sw1.WriteLine(TmpSerialNo12);
                                        //                    sw1.WriteLine(TmpL21);
                                        //                    sw1.WriteLine(TmpL22);
                                        //                    sw1.WriteLine(TmpL23);
                                        //                    sw1.WriteLine(TmpL24);
                                        //                    sw1.WriteLine(TmpL25);
                                        //                    sw1.WriteLine(TmpL26);
                                        //                    sw1.WriteLine(TmpL27);
                                        //                    sw1.WriteLine(TmpL28);
                                        //                    sw1.WriteLine(TmpL29);
                                        //                    sw1.WriteLine(TmpL20);
                                        //                    sw1.WriteLine(TmpL104);

                                        //                    ProcessStartInfo psi1 = new ProcessStartInfo(("D:\\test\\BatchPrn2.bat"));
                                        //                    Process process1 = Process.Start(psi1);





                                                             
                                        //                    ////ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Printing Complete ... ');", true);
                                        //                    ////GridLoad();
                                        //                }

                                        //                string fileName = @"D:\test\testingdata.txt";
                                        //                var lines = File.ReadAllLines(fileName);
                                        //                for (var dd = 0; dd < lines.Length; dd += 1)
                                        //                {
                                        //                    string line = lines[0];
                                        //                    string line1 = lines[1];
                                        //                    string line2 = lines[2];
                                        //                    string line3 = lines[3];
                                        //                    string line4 = lines[4];
                                        //                    string line5 = lines[5];
                                        //                    string line6 = lines[6];
                                        //                    string line7 = lines[7];
                                        //                    string line8 = lines[8];
                                        //                    string line9 = lines[9];
                                        //                    string line10 = lines[10];
                                        //                    string line11 = lines[11];
                                        //                    string line12 = lines[12];

                                        //                    string Palletid = line10;

                                        //                    int values = db.ExecuteQuery(" update printrfid set palletrfid='" + line10 + "' where palletid='" + PAlletid + "'");

                                        //                    if (values > 0)
                                        //                    {

                                        //                    }
                                        //                    // Process line
                                        //                }
                                        //            }
                                        //        }
                                        //    }
                                        }
                                    }
                                }
                                else
                                {
                                    //PAlletid = PAlletid + 1;
                                    string time = "01";
                                    string datetime = datetim + "" + time;
                                    int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                             " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + datetime + "','" + PAlletid + "')");
                                    if (vl > 0)
                                    {
                                    }
                                }
                            }
                        }                       
                            string query1 = "select itemcode,Is_active,sno from printrfid where Is_active=0";
                            DataSet dsdaa = db.SelectQuery(query1);
                            DataTable dt1 = dsdaa.Tables[0];
                            int k1 = 0;
                            if (dsdaa.Tables[0].Rows.Count > 0)
                            {
                                //string snos = dsda.Tables[0].Rows[0]["sno"].ToString();
                                int datacount = dsdaa.Tables[0].Rows.Count;
                                int palletcount = datacount + 1;
                                foreach (DataRow dr in dt1.Rows)
                                {
                                    if (dr["Is_active"].ToString() != "False")
                                    {

                                    }
                                    else
                                    {
                                        if (k1 != palletcount)
                                        {
                                            Thread.Sleep(5000);
                                            //string printerrfid = dr["printerRfidID"].ToString();
                                            string Itemcodes = dr["Itemcode"].ToString();
                                            string snos = dr["sno"].ToString();
                                            string fileLoca = @"c:\test\sample1.txt";
                                            // string fileLoc = @"E:\test\sample1.txt";
                                            if (File.Exists(fileLoca))
                                            {
                                                using (StreamWriter sw = new StreamWriter(fileLoca))
                                                {
                                                    //data="! U1 setvar ";
                                                    //data1=" rfid.log.enabled";
                                                    //string je="v";
                                                    //data3=" on";

                                                    //data5 = data + "" + data1 + "";
                                                    //data4 = "^XA^FN0^FS^FN0^RFR,H^FS~HL^HV0^XZ";

                                                    TmpSerialNo = "^XA~SD30^MNW^MTT~TA0000^JUS^XZ";
                                                    TmpSerialNo1 = "^XA";
                                                    TmpL1 = "^PW584";
                                                    TmpL2 = "^LL0104";
                                                    TmpL3 = "^LS0";
                                                    TmpL4 = "^FO10,90^A0N,22^FN0^FS^FN0^RFR,H^FS";
                                                    TmpL5 = "^HL^HV0^FT10,70^A0N,28,28^FDItem Code-" + textBox1.Text + "^FS";
                                                    TmpL6 = "^FO400,30^BQN,3,3^FD Item Code-" + textBox1.Text + "^FS";
                                                    TmpL7 = "^XZ";
                                                   // TmpL8 = "^FH\\^FDLA,Item Code-" + textBox1.Text + "";
                                                   // TmpL9 = "FH\\^FDLA,RFR,H^FS";
                                                   // TmpL10 = "FT40,70^A0N,25,25^FH\\^FDItem Code-" + textBox1.Text + "\\RFR,H^FS";
                                                   // TmpL101 = "^XZ";
                                                    //sw.WriteLine(data5);
                                                    //sw.WriteLine(data4);
                                                    sw.WriteLine(TmpSerialNo);
                                                    sw.WriteLine(TmpSerialNo1);
                                                    sw.WriteLine(TmpL1);
                                                    sw.WriteLine(TmpL2);
                                                    sw.WriteLine(TmpL3);
                                                    sw.WriteLine(TmpL4);
                                                    sw.WriteLine(TmpL5);
                                                    sw.WriteLine(TmpL6);
                                                    sw.WriteLine(TmpL7);
                                                    //sw.WriteLine(TmpL8);
                                                    //sw.WriteLine(TmpL9);
                                                    //sw.WriteLine(TmpL10);
                                                    //sw.WriteLine(TmpL101);

                                                    string sample = @"c:\test\BatchPrn.BAT";

                                                    ProcessStartInfo startInfo = new ProcessStartInfo();
                                                    startInfo.CreateNoWindow = true;
                                                    startInfo.UseShellExecute = true;
                                                    startInfo.FileName = sample;
                                                    startInfo.Arguments = "p1=hardCodedv1 p2=v2";
                                                    Process.Start(startInfo);

                                                    //ProcessStartInfo psi = new ProcessStartInfo(("c:\\test\\BatchPrn.BAT"));
                                                    //Process process = Process.Start(psi);

                                                    dr["Is_active"] = "True";

                                                    // string fileLoc = @"E:\test\sample1.txt";


                                                    // string arye = "update printrfid Set Is_active=1 where printerrfidID= '" + printerrfid + "'";
                                                    // int v = db.ExecuteQuery(arye);
                                                    //i = i + 1;

                                                }
                                            }
                                            string fileName = @"c:\test\sample1.txt";
                                            var lines = File.ReadAllLines(fileName);
                                            
                                                string line = lines[0];
                                                string line1 = lines[1];
                                                string line2 = lines[2];
                                                string line3 = lines[3];
                                                string line4 = lines[4];
                                                string line5 = lines[5];
                                                string line6 = lines[6];
                                                string line7 = lines[7];
                                                string line8 = lines[8];
                                                 

                                                string Palletid = line5;

                                                int values = db.ExecuteQuery(" update printrfid set printerrfidid='" + line5 + "',Is_active=1 where sno='" + snos + "'");

                                                if (values > 0)
                                                {

                                                }

                                                // Process line
                                            
                                        }
                                        else
                                        {
                                            //Thread.Sleep(5000);                            
                                        }
                                    }
                                }
                                if (palletcount == datacount + 1)
                                {
                                    string fileLoc = @"c:\test\sample1.txt";
                                    // string fileLoc = @"E:\test\sample1.txt";
                                    if (File.Exists(fileLoc))
                                    {
                                        using (StreamWriter sw1 = new StreamWriter(fileLoc))
                                        {
                                            TmpSerialNo11 = "^XA";
                                            TmpSerialNo12 = "^FO80,70";
                                            TmpL21 = "^A0N,35";
                                            TmpL22 = "^FN0";
                                            TmpL23 = "^FS";
                                            TmpL24 = "^FN0";
                                            TmpL25 = "^RFR,H";
                                            TmpL26 = "^FS";
                                            TmpL27 = "^HL^HV0^FS";
                                            TmpL28 = "^XZ";

                                            sw1.WriteLine(TmpSerialNo11);
                                            sw1.WriteLine(TmpSerialNo12);
                                            sw1.WriteLine(TmpL21);
                                            sw1.WriteLine(TmpL22);
                                            sw1.WriteLine(TmpL23);
                                            sw1.WriteLine(TmpL24);
                                            sw1.WriteLine(TmpL25);
                                            sw1.WriteLine(TmpL26);
                                            sw1.WriteLine(TmpL27);
                                            sw1.WriteLine(TmpL28);
                                            //sw1.WriteLine(TmpL28);
                                            //sw1.WriteLine(TmpL29);
                                            //sw1.WriteLine(TmpL20);
                                            //sw1.WriteLine(TmpL104);

                                            string sample = @"c:\test\BatchPrn.BAT";

                                            ProcessStartInfo startInfo = new ProcessStartInfo();
                                            startInfo.CreateNoWindow = true;
                                            startInfo.UseShellExecute = true;
                                            startInfo.FileName = sample;
                                            startInfo.Arguments = "p1=hardCodedv1 p2=v2";
                                            Process.Start(startInfo);


                                            ////ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Printing Complete ... ');", true);
                                            ////GridLoad();
                                        }

                                        string fileName = @"c:\test\sample1.txt";
                                        var lines = File.ReadAllLines(fileName);
                                        
                                            string line = lines[0];
                                            string line1 = lines[1];
                                            string line2 = lines[2];
                                            string line3 = lines[3];
                                            string line4 = lines[4];
                                            string line5 = lines[5];
                                            string line6 = lines[6];
                                            string line7 = lines[7];
                                            string line8 = lines[8];
                                            string line9 = lines[9];
                                             

                                            string Palletid = line6;

                                            int values = db.ExecuteQuery(" update printrfid set palletrfid='" + line6 + "',flg=1 where flg=0");

                                            if (values > 0)
                                            {

                                            }

                                            // Process line
                                        
                                    }
                                }
                            }
                        
                        this.Close();
                    
                }
                else if (result1 == DialogResult.No)
                {
                    int count = Convert.ToInt32(textBox4.Text);
                    string datetim = DateTime.Now.ToString("ddMMyy");
                    DataSet ds1 = new DataSet();
                    DataSet ds2 = new DataSet();
                    ds2 = db.SelectQuery("select PAlletid from printrfid order by PAlletid desc ");
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        int PAlletid = Convert.ToInt32(ds2.Tables[0].Rows[0]["PAlletid"].ToString());
                        PAlletid = PAlletid + 1;
                        for (int i = 0; count > i; i++)
                        {
                            ds1 = db.SelectQuery("select BatchNo from printrfid where Convert(date,printerDate)=CONVERT(date,Getdate()) order by Batchno desc ");
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                string BatchNo = ds1.Tables[0].Rows[0]["BatchNo"].ToString();
                                int Batch = Convert.ToInt32(BatchNo);
                                int das = Convert.ToInt32(Batch + 1);
                                string das1 = Convert.ToString(das);
                                int count1 = das1.Length;
                                if (count1 > 7)
                                {
                                    int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                             " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + das + "','" + PAlletid + "')");
                                    if (vl > 0)
                                    {

                                    }
                                }
                                else
                                {
                                    string das2 = "0" + das1;
                                    int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                            " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + das2 + "','" + PAlletid + "')");
                                    if (vl > 0)
                                    {
                                    }
                                }
                            }
                            else
                            {
                                PAlletid = PAlletid + 1;
                                string time = "01";
                                string datetime = datetim + "" + time;
                                int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                         " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + datetime + "','" + PAlletid + "')");
                                if (vl > 0)
                                {
                                }
                            }

                        }
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox4.Text = string.Empty;
                        fillgrid();
                    }
                    else
                    {
                        int PAlletid = 1;
                        //PAlletid = PAlletid + 1;
                        for (int i = 0; count > i; i++)
                        {
                            ds1 = db.SelectQuery("select BatchNo from printrfid where Convert(date,printerDate)=CONVERT(date,Getdate()) order by Batchno desc ");
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                string BatchNo = ds1.Tables[0].Rows[0]["BatchNo"].ToString();
                                int Batch = Convert.ToInt32(BatchNo);
                                int das = Convert.ToInt32(Batch + 1);
                                string das1 = Convert.ToString(das);
                                int count1 = das1.Length;
                                if (count1 > 7)
                                {
                                    int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                             " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + das + "','" + PAlletid + "')");
                                    if (vl > 0)
                                    {

                                    }
                                }
                                else
                                {
                                    string das2 = "0" + das1;
                                    int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                            " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + das2 + "','" + PAlletid + "')");
                                    if (vl > 0)
                                    {
                                    }
                                }
                            }
                            else
                            {
                                //PAlletid = PAlletid + 1;
                                string time = "01";
                                string datetime = datetim + "" + time;
                                int vl = db.ExecuteQuery(" insert into printrfid (Itemcode,Description,Is_active,BoxCount,flg,BatchNo,PAlletid) " +
                                                         " values( '" + textBox1.Text + "','" + textBox2.Text + "','0','1','0','" + datetime + "','" + PAlletid + "')");
                                if (vl > 0)
                                {
                                }
                            }
                        }
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox4.Text = string.Empty;
                        fillgrid();
                    }
                }
            }
        }
    }
}