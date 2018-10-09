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
            var strg = Application.StartupPath.ToString();
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg += @"\Data";
            textBox1.Text = strg + "\\" + "mrcy.bak";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var str = "use master restore database db_MrCy from Disk='"+textBox1.Text.Trim()+"'";
                var conn = BaseClass.DBConn.CyCon();
                conn.Open();
                var cmd = new SqlCommand(str,conn);
                cmd.ExecuteNonQuery();
                if (MessageBox.Show("�ָ��ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
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