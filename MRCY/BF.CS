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
    public partial class BF : Form
    {
        public BF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBF_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var strg = Application.StartupPath.ToString();
                strg = strg.Substring(0, strg.LastIndexOf("\\"));
                strg = strg.Substring(0, strg.LastIndexOf("\\"));
                strg += @"\Data";
                var sqltxt = @"BACKUP DATABASE db_MrCy TO Disk='" + strg + "\\" + txtpath.Text +".bak"+ "'";
                var conn = BaseClass.DBConn.CyCon();
                conn.Open();
                var cmd = new SqlCommand(sqltxt, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                if (MessageBox.Show("���ݳɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}