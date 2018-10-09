using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MrCy.BaseClass;

namespace MrCy {
    public partial class Open : Form {
        public Open() {
            InitializeComponent();
        }


        public string name;
        public SqlConnection conn;

        private void frmOpen_Load(object sender, EventArgs e) {
            conn = DbConn.CyCon();
            conn.Open();
            var cmd = new SqlCommand("select * from tb_Room", conn);
            var sdr = cmd.ExecuteReader();
            while (sdr.Read()) {
                cbNum.Items.Add(sdr["RoomName"].ToString().Trim());
            }

            cbNum.SelectedItem = name.Trim();
            sdr.Close();
            cmd = new SqlCommand("select * from tb_Waiter", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read()) {
                cbWaiter.Items.Add(sdr["WaiterName"].ToString().Trim());
            }

            cbWaiter.SelectedIndex = 0;
            sdr.Close();
        }


        private void txtNum_KeyPress(object sender, KeyPressEventArgs e) {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13) {
                MessageBox.Show("请输入数字");
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (txtNum.Text == "" || Convert.ToInt32(txtNum.Text) <= 0) {
                MessageBox.Show("请输入用餐人数");
            }
            else {
                var RoomName = cbNum.SelectedItem.ToString();
                var cmd1 = new SqlCommand(
                    "update tb_Room set GuestName='" + txtName.Text + "',zhangdanDate='" +
                    dateTimePicker1.Value.ToString() + "',Num='" + Convert.ToInt32(txtNum.Text) + "',WaiterName='" +
                    cbWaiter.SelectedItem.ToString() + "',RoomZT='使用' where RoomName='" + name + "'", conn);
                cmd1.ExecuteNonQuery();
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}