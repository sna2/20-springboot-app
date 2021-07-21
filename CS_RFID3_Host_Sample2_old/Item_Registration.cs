using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CS_RFID3_Host_Sample2;

namespace CS_RFID3_Host_Sample2
{
    public partial class Item_Registration : Form
    {
        private DAccess2 data2 = new DAccess2();
        private AppForm appForm;
        public Item_Registration()
        {
            InitializeComponent();
        }

        public Item_Registration(AppForm appForm)
        {
            // TODO: Complete member initialization
            this.appForm = appForm;
            InitializeComponent();
            displayDataGridView();

            DataGridViewLinkColumn Addlink = new DataGridViewLinkColumn();
            Addlink.UseColumnTextForLinkValue = true;
            Addlink.HeaderText = "Add";
            Addlink.DataPropertyName = "lnkColumn";
            Addlink.LinkBehavior = LinkBehavior.SystemDefault;
            Addlink.Text = "Add";
            gvstockIn.Columns.Add(Addlink);           

            //DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            //Editlink.UseColumnTextForLinkValue = true;
            //Editlink.HeaderText = "Edit";
            //Editlink.DataPropertyName = "lnkColumn";
            //Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            //Editlink.Text = "Edit";
            //gvstockIn.Columns.Add(Editlink);

            //DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            //Deletelink.UseColumnTextForLinkValue = true;
            //Deletelink.HeaderText = "delete";
            //Deletelink.DataPropertyName = "lnkColumn";
            //Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            //Deletelink.Text = "Delete";
            //gvstockIn.Columns.Add(Deletelink);
        }

        private void gvstockIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check whether user click on the first column 
            if (e.ColumnIndex == 0)
            {
                int row;
                //Get the row index
                row = e.RowIndex;
                //Create instance of the form2 class
                Item_Registration obj = new Item_Registration();
                //Bind the datagridview values in the second popup form
                obj.Controls["TextBox1"].Text = gvstockIn.Rows[row].Cells[1].Value.ToString();
                obj.Controls["TextBox2"].Text = gvstockIn.Rows[row].Cells[2].Value.ToString();
                obj.Controls["TextBox3"].Text = gvstockIn.Rows[row].Cells[3].Value.ToString();
                obj.Controls["TextBox4"].Text = gvstockIn.Rows[row].Cells[4].Value.ToString();
                obj.Controls["TextBox5"].Text = gvstockIn.Rows[row].Cells[5].Value.ToString();
                obj.Controls["TextBox6"].Text = gvstockIn.Rows[row].Cells[6].Value.ToString();
                obj.ShowDialog();
            }
        }

        private void gvstockIn_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = 1;
            if (e.ColumnIndex == 6)
            {
                int row;
                //Get the row index
                row = e.RowIndex;
                i = i++;
                //Create instance of the form2 class
                NewItem obj = new NewItem();
                //Bind the datagridview values in the second popup form
                //obj.Controls["ItemCode"].Text = gvstockIn.Rows[row].Cells[1].Value.ToString();
                //obj.Controls["Description"].Text = gvstockIn.Rows[row].Cells[2].Value.ToString();
                //obj.Controls["UOM"].Text = gvstockIn.Rows[row].Cells[3].Value.ToString();
                //obj.Controls["Boxcount"].Text = gvstockIn.Rows[row].Cells[4].Value.ToString();
                //obj.Controls["BoxQty"].Text = gvstockIn.Rows[row].Cells[5].Value.ToString();
                //obj.Controls["printerDate"].Text = gvstockIn.Rows[row].Cells[6].Value.ToString();
                obj.ShowDialog();
            }
        }

        public void displayDataGridView()
        {
            DataSet ds = new DataSet();
            ds = data2.SelectQuery("select PAlletid SNo,ItemCode,Description,UOM,Boxcount,BoxQty from logsdatas1 order by PAlletid desc");
           // ds = data2.SelectQuery("select SNO,ItemCode,Description,UOM,Boxcount,BoxQty,printerDate from logsdatas1 order by printerDate desc");
            if (ds.Tables[0].Rows.Count > 0)
            {               
                gvstockIn.DataSource = ds.Tables[0];
                gvstockIn.AutoGenerateColumns = false;
                gvstockIn.AllowUserToAddRows = false;
                //int i = 1;
                //foreach (DataGridViewRow row in gvstockIn.Rows)
                //{
                //    row.Cells["SNO"].Value = i;
                //    i++;
                //}
            }
            else
            {

            }
        }

        private void Item_Registration_Load(object sender, EventArgs e)
        {
            displayDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }       
    }
}