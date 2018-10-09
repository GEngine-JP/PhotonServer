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
    public partial class Lock : Form
    {
        public Lock()
        {
            InitializeComponent();
        }

        private void frmLock_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = BaseClass.DBConn.CyCon();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from tb_User where UserPwd='" + textBox1.Text.Trim() + "'", conn);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            if (i > 0)
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("ÃÜÂë´íÎó", "¾¯¸æ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    textBox1.Text = "";
                    textBox1.Focus();
                }

            }
        }

        private void frmLock_Load(object sender, EventArgs e)
        {

        }

        private void frmLock_KeyDown(object sender, KeyEventArgs e)
        {
      
        }
    }
}