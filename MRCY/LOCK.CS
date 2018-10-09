using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MrCy.BaseClass;

namespace MrCy {
    public partial class Lock : Form {
        public Lock() {
            InitializeComponent();
        }

        private void frmLock_KeyPress(object sender, KeyPressEventArgs e) {
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            var conn = DbConn.CyCon();
            conn.Open();
            var cmd = new SqlCommand("select count(*) from tb_User where UserPwd='" + textBox1.Text.Trim() + "'", conn);
            var i = Convert.ToInt32(cmd.ExecuteScalar());
            if (i > 0) {
                this.Close();
            }
            else {
                if (MessageBox.Show("密码错误", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                    DialogResult.OK) {
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
        }

        private void frmLock_Load(object sender, EventArgs e) {
        }

        private void frmLock_KeyDown(object sender, KeyEventArgs e) {
        }
    }
}