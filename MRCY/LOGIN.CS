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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }


        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("�������û���", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtPwd.Text == "")
                {
                    MessageBox.Show("����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlConnection conn = BaseClass.DBConn.CyCon();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) from tb_User where UserName='" + txtName.Text + "' and UserPwd='" + txtPwd.Text + "'", conn);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    if (i > 0)
                    {
                        cmd = new SqlCommand("select * from tb_User where UserName='" + txtName.Text + "'", conn);
                        SqlDataReader sdr = cmd.ExecuteReader();
                        sdr.Read();
                        string UserPower = sdr["power"].ToString().Trim();
                        conn.Close();
                        Main main = new Main();
                        main.power = UserPower;
                        main.Names = txtName.Text;
                        main.Times = DateTime.Now.ToShortDateString();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("�û������������");
                    }
                }
            }
        }

        private void btnConcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ���˳�ϵͳ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}