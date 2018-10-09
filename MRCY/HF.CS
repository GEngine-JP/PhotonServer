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
    public partial class HF : Form
    {
        public HF()
        {
            InitializeComponent();
        }

        private void frmHF_Load(object sender, EventArgs e)
        {
            string strg = Application.StartupPath.ToString();
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg += @"\Data";
            textBox1.Text = strg + "\\" + "mrcy.bak";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "use master restore database db_MrCy from Disk='"+textBox1.Text.Trim()+"'";
                SqlConnection conn = BaseClass.DBConn.CyCon();
                conn.Open();
                SqlCommand cmd = new SqlCommand(str,conn);
                cmd.ExecuteNonQuery();
                if (MessageBox.Show("恢复成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}