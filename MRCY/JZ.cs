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
    public partial class JZ : Form
    {
        public JZ()
        {
            InitializeComponent();
        }
        public string Rname;
        public string price;
        public string bjf;
        private void frmJZ_Load(object sender, EventArgs e)
        {
            this.Text = Rname + "结账";
            groupBox1.Text = "当前桌台-" + Rname;
            SqlConnection conn = BaseClass.DBConn.CyCon();
            SqlDataAdapter sda = new SqlDataAdapter("select foodname,foodsum,foodallprice,waitername,beizhu,zhuotai,datatime from tb_GuestFood where zhuotai='" + Rname + "'order by ID desc", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvRecord.DataSource = ds.Tables[0];
            conn.Open();
            SqlCommand cmd = new SqlCommand("select sum(foodallprice) from tb_GuestFood where zhuotai='" + Rname + "'", conn);
            price = Convert.ToString(cmd.ExecuteScalar());
            if (price == "")
            {
                lblprice.Text = "0";
                btnJZ.Enabled = false;
            }
            else
            {
                cmd = new SqlCommand("select RoomBJF from tb_Room where RoomName='"+Rname+"'", conn);
                bjf = cmd.ExecuteScalar().ToString();
                if (bjf == "0")
                {
                    btnJZ.Enabled = true;
                    lblprice.Text = price + "*95%"+"+"+bjf+"=" + (Convert.ToDecimal(Convert.ToDouble(price) * Convert.ToDouble(0.95))).ToString("C");
                }
                else
                {
                    btnJZ.Enabled = true;
                    lblprice.Text = price + "*95%"+"+"+bjf+"=" + (Convert.ToDecimal(Convert.ToDouble(price) * Convert.ToDouble(0.95)) + Convert.ToDecimal(bjf)).ToString("C");
                }
                conn.Close();
            }
        }

        private void txtmoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字");
                e.Handled = true;
            }
        }

        private void txtmoney_TextChanged(object sender, EventArgs e)
        {
            if (price == "")
            {
                lbl0.Text = "0";
            }
            else
            {
                if (txtmoney.Text == "")
                {
                    txtmoney.Text = "0";
                    lbl0.Text = "0";
                }
                else
                {
                    lbl0.Text = Convert.ToDecimal(Convert.ToDouble(txtmoney.Text.Trim()) - Convert.ToDouble(price) * Convert.ToDouble(0.95) - Convert.ToDouble(bjf)).ToString("C");
                }
            }
        }
        private void btnJZ_Click(object sender, EventArgs e)
        {
            if (txtmoney.Text == ""||lbl0.Text=="0")
            {
                MessageBox.Show("请先结账");
                return;
            }
            else
            {
                if (lbl0.Text.Substring(1, 1) == "-")
                {
                    MessageBox.Show("金额不足");
                    return;
                }
                else
                {
                    SqlConnection conn = BaseClass.DBConn.CyCon();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from tb_GuestFood where zhuotai='" + Rname + "'", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update tb_Room set RoomZT='待用',Num=0,WaiterName='' where RoomName='" + Rname + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    this.Close();

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}