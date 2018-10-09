using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MrCy.BaseClass;

namespace MrCy {
    public partial class HF : Form {
        public HF() {
            InitializeComponent();
        }

        private void frmHF_Load(object sender, EventArgs e) {
            var strg = Application.StartupPath;
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg += @"\Data";
            textBox1.Text = strg + "\\" + "mrcy.bak";
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                var str = "use master restore database db_MrCy from Disk='" + textBox1.Text.Trim() + "'";
                var conn = DbConn.CyCon();
                conn.Open();
                var cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
                if (MessageBox.Show(Constants.ExitSystem, Constants.Warn, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) ==
                    DialogResult.OK) {
                    this.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}