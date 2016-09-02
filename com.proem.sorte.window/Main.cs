using Branch;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.window.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sorteSystem.com.proem.sorte.window
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sorteList sorteList = new sorteList(this);
            sorteList.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process process = new Process(this);
            process.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定退出系统?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                //释放全部连接池资源
                OracleConnection.ClearAllPools();
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
            }     
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                button2_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.F2)
            {
                button3_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.F3)
            {
                button4_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.F4){
                button5_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.Escape)
            {
                button1_Click(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 点击进入退货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            ReturnGoods obj = new ReturnGoods(this);
            obj.Show();
            this.Hide();
        }

        /// <summary>
        /// 点击进入扫码收银
        /// 不按照订单来的收银
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            SorteWithoutOrder sorteWithOutOrder = new SorteWithoutOrder(this);
            sorteWithOutOrder.Show();
            this.Hide();
        }
    }
}
