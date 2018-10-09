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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        private void BindData()
        {
            SqlConnection conn = BaseClass.DBConn.CyCon();
            SqlDataAdapter sda = new SqlDataAdapter("select WaiterName,CardNum,WaiterNum,Sex,Age,Tel,ID from tb_Waiter order by ID desc", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txtjc.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txtbjf.Text = dataGridView1.SelectedCells[2].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedCells[3].Value.ToString().Trim();
            txtlx.Text = dataGridView1.SelectedCells[4].Value.ToString();
            txtbz.Text = dataGridView1.SelectedCells[5].Value.ToString();
            button2.Enabled = true;
            button6.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtlx.Text = "";
            txtjc.Text = "";
            txtbz.Text = "";
            txtbjf.Text = "";
            txtname.Enabled = true;
            txtjc.Enabled = true;
            txtbjf.Enabled = true;
            comboBox1.Enabled = true;
            txtlx.Enabled = true;
            txtbz.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            txtname.Enabled = false;
            txtjc.Enabled = true;
            txtbjf.Enabled = true;
            this.comboBox1.Enabled = true;
            txtlx.Enabled = true;
            txtbz.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = BaseClass.DBConn.CyCon();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from tb_Waiter where WaiterName='" + txtname.Text + "'", conn);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            if (i > 0)
            {
                cmd = new SqlCommand("update tb_Waiter set WaiterName='" + txtname.Text + "',CardNum='" + txtjc.Text + "',WaiterNum='" + txtbjf.Text + "',Sex='" + comboBox1.SelectedItem.ToString() + "',Age='" + txtlx.Text + "',Tel='" + txtbz.Text + "' where ID='" + dataGridView1.SelectedCells[6].Value.ToString() + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                BindData();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = true;
                button6.Enabled = false;
                button7.Enabled = true;
                txtname.Enabled = false;
            }
            else
            {
                cmd = new SqlCommand("insert into tb_Waiter(WaiterName,CardNum,WaiterNum,Sex,Age,Tel) values('" + txtname.Text + "','" + txtjc.Text + "','" + txtbjf.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + txtlx.Text + "','" + txtbz.Text + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                BindData();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = true;
                button6.Enabled = false;
                button7.Enabled = true;
                txtname.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            txtname.Enabled = false;
            txtjc.Enabled = false;
            txtbjf.Enabled = false;
            this.comboBox1.Enabled = false;
            txtlx.Enabled = false;
            txtbz.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = BaseClass.DBConn.CyCon();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from tb_Waiter where ID='" + dataGridView1.SelectedCells[6].Value.ToString() + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            BindData();
        }
    }
}