using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MrCy.BaseClass;

namespace MrCy {
    public partial class Details : Form {
        public Details() {
            InitializeComponent();
        }

        public string TableName;

        private void frmDetails_Load(object sender, EventArgs e) {
            txtName.Text = TableName.Trim();
            var conn = DBConn.CyCon();
            conn.Open();
            var cmd = new SqlCommand("select * from tb_Room where RoomName='" + txtName.Text + "'", conn);
            var sdr = cmd.ExecuteReader();
            sdr.Read();
            txtNum.Text = sdr["ID"].ToString().Trim();
            txtJc.Text = sdr["RoomJC"].ToString().Trim();
            txtBjf.Text = sdr["RoomBJF"].ToString().Trim();
            txtWz.Text = sdr["RoomWZ"].ToString().Trim();
            txtZt.Text = sdr["RoomZT"].ToString().Trim();
            txtLx.Text = sdr["RoomType"].ToString().Trim();
            txtBz.Text = sdr["RoomBZ"].ToString().Trim();
            var qt = sdr["zhangdandate"].ToString() + "开始用餐" + "\n" + "用餐人数：" + sdr["Num"].ToString();
            richTextBox1.Text = txtZt.Text == "待用" ? "暂时没有其他信息..." : qt;
            sdr.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}