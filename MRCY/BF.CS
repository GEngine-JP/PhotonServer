using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MrCy.BaseClass;

namespace MrCy {
    public partial class BF : Form {
        public BF() {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void frmBF_Load(object sender, EventArgs e) {
        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                var strg = Application.StartupPath;
                strg = strg.Substring(0, strg.LastIndexOf("\\"));
                strg = strg.Substring(0, strg.LastIndexOf("\\"));
                strg += @"\Data";
                var sqltxt = @"BACKUP DATABASE db_MrCy TO Disk='" + strg + "\\" + txtpath.Text + ".bak" + "'";
                var conn = DBConn.CyCon();
                conn.Open();
                var cmd = new SqlCommand(sqltxt, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                if (MessageBox.Show("this is tips content", "tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) ==
                    DialogResult.OK) {
                    this.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}