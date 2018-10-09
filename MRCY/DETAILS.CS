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
    public partial class Details : Form
    {
        public Details()
        {
            InitializeComponent();
        }
        public string TableName;
        private void frmDetails_Load(object sender, EventArgs e)
        {
            txtName.Text = TableName.Trim();
            SqlConnection conn = BaseClass.DBConn.CyCon();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_Room where RoomName='"+txtName.Text+"'",conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            txtNum.Text = sdr["ID"].ToString().Trim();
            txtJc.Text = sdr["RoomJC"].ToString().Trim();
            txtBjf.Text = sdr["RoomBJF"].ToString().Trim();
            txtWz.Text=sdr["RoomWZ"].ToString().Trim();
            txtZt.Text = sdr["RoomZT"].ToString().Trim();
            txtLx.Text = sdr["RoomType"].ToString().Trim();
            txtBz.Text = sdr["RoomBZ"].ToString().Trim();
            string qt = sdr["zhangdandate"].ToString() + "开始用餐" + "\n" + "用餐人数：" + sdr["Num"].ToString();
            if (txtZt.Text=="待用")
            {
                richTextBox1.Text = "暂时没有其他信息...";
            }
            else
            {
                richTextBox1.Text = qt;
            }
            sdr.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}