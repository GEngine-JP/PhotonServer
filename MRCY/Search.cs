using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MrCy.BaseClass;

namespace MrCy
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        public string RName;

        private void FrmSearchLoad(object sender, EventArgs e)
        {
            var conn = DbConn.CyCon();
            var sda = new SqlDataAdapter(
                "select foodname,foodsum,foodallprice,waitername,beizhu,zhuotai,datatime from tb_GuestFood where zhuotai='" +
                RName + "'order by ID desc", conn);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}