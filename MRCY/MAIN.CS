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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public SqlDataReader sdr;
        public string power;
        public string Names;
        public string Times;
        private void frmMain_Load(object sender, EventArgs e)
        {
                switch (power)
                {
                    case "0": toolStripStatusLabel13.Text = "超级管理员"; break;
                    case "1": toolStripStatusLabel13.Text = "经理"; break;
                    case "2": toolStripStatusLabel13.Text = "一般用户"; break;
                }
            toolStripStatusLabel10.Text = Names;
            toolStripStatusLabel16.Text = Times;
            if (power == "2")
            {
                系统维护SToolStripMenuItem.Enabled = false;
                基础信息MToolStripMenuItem.Enabled = false;
            }
            if (power == "1")
            {
                系统维护SToolStripMenuItem.Enabled = false;
            }
            
        }
        private void AddItems(string rzt)
        {
            if (rzt == "使用")
            {
                lvDesk.Items.Add(sdr["RoomName"].ToString(), 1);
            }
            else
            {
                lvDesk.Items.Add(sdr["RoomName"].ToString(), 0);
            }
        }


        private void 开台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {

                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                Open openroom = new Open();
                openroom.name = names;
                openroom.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择桌台");
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            lvDesk.Items.Clear();
            SqlConnection conn = BaseClass.DBConn.CyCon();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_Room", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string zt = sdr["RoomZT"].ToString().Trim();
                AddItems(zt);
            }
            conn.Close();
        }
        private void 点菜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                DC dc = new DC();
                dc.RName = names;
                dc.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择桌台");
            }
        }

        private void 消费查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                Serch serch = new Serch();
                serch.RName = names;
                serch.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择桌台");
            }
        }
        private void 结账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                JZ jz = new JZ();
                jz.Rname = names;
                jz.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择桌台");
            }

        }
        private void lvDesk_DoubleClick(object sender, EventArgs e)
        {
            Details details = new Details();
            details.TableName = lvDesk.SelectedItems[0].SubItems[0].Text;
            details.ShowDialog();
        }
        private void lvDesk_Click(object sender, EventArgs e)
        {
            string names = lvDesk.SelectedItems[0].SubItems[0].Text;
            SqlConnection conn = BaseClass.DBConn.CyCon();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_Room where RoomName='" + names + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string zt = sdr["RoomZT"].ToString().Trim();
            sdr.Close();
            if (zt == "使用")
            {
                this.contextMenuStrip1.Items[0].Enabled = false;
                this.contextMenuStrip1.Items[1].Enabled = true;
                this.contextMenuStrip1.Items[3].Enabled = true;
                this.contextMenuStrip1.Items[5].Enabled = true;
                this.contextMenuStrip1.Items[6].Enabled = true;
            }
            if (zt == "待用")
            {
                this.contextMenuStrip1.Items[0].Enabled = true;
                this.contextMenuStrip1.Items[1].Enabled = false;
                this.contextMenuStrip1.Items[3].Enabled = false;
                this.contextMenuStrip1.Items[5].Enabled = false;
                this.contextMenuStrip1.Items[6].Enabled = false;
            }
            conn.Close();
        }

        private void 取消开台toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                SqlConnection conn = BaseClass.DBConn.CyCon();
                conn.Open();
                SqlCommand cmd = new SqlCommand("update tb_Room set RoomZT='待用',Num=0 where RoomName='" + names + "'", conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("delete from tb_GuestFood where zhuotai='" + names + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                frmMain_Activated(sender, e);
            }
            else
            {
                MessageBox.Show("请选择桌台");
            }
        }
        private void 桌台信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Desk desk = new Desk();
            desk.ShowDialog();
        }

        private void 职员信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            User users = new User();
            users.ShowDialog();
        }

        private void 日历ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Calender calender = new Calender();
            calender.ShowDialog();
        }

        private void 记事本ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void 计算器ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void 权限管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QxGl qx = new QxGl();
            qx.ShowDialog();
        }

        private void 系统备份ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BF bf = new BF();
            bf.ShowDialog();
        }

        private void 系统恢复ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HF hf = new HF();
            hf.ShowDialog();
        }

        private void 口令设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pwd pwd = new Pwd();
            pwd.names = Names;
            pwd.ShowDialog();
        }

        private void 锁定系统ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Lock locksystem = new Lock();
            locksystem.Owner = this;
            locksystem.ShowDialog();
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出本系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void 系统维护SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}