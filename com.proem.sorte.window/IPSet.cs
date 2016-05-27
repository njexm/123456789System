using sorteSystem.com.proem.sorte.util;
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
    public partial class IPSet : Form
    {
        public IPSet()
        {
            InitializeComponent();
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sureButton_Click(object sender, EventArgs e)
        {
            if (oneTextBox.Text.Equals("") || twoTextBox.Text.Equals(""))
            {
                MessageBox.Show("存在尚未设定IP");
            }
            else
            {
                ConstantUtil.ip1 = oneTextBox.Text.ToString();
                ConstantUtil.ip2 = twoTextBox.Text.ToString();
                this.Close();
            }
        }

        private void IPSet_Load(object sender, EventArgs e)
        {
            oneTextBox.Text = ConstantUtil.ip1;
            twoTextBox.Text = ConstantUtil.ip2;
        }
    }
}
