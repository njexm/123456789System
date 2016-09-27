using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sorteSystem.com.proem.sorte.window.util
{
    public partial class MessageFail : Form
    {
        public MessageFail()
        {
            InitializeComponent();
        }

        private void MessageFail_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                button1_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.Escape){
                button1_Click(this, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
