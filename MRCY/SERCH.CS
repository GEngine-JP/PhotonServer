using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MrCy
{
    public partial class Serch : Form
    {
        public Serch()
        {
            InitializeComponent();
        }
        public string RName;
        private void frmSerch_Load(object sender, EventArgs e)
        {
            SqlConnection conn = BaseClass.DBConn.CyCon();
            SqlDataAdapter sda = new SqlDataAdapter("select foodname,foodsum,foodallprice,waitername,beizhu,zhuotai,datatime from tb_GuestFood where zhuotai='" + RName + "'order by ID desc", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}