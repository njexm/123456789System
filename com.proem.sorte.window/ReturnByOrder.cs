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
    public partial class ReturnByOrder : Form
    {
        public ReturnByOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 输入框输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_TextChanged(object sender, EventArgs e)
        {
            string searchString = search.Text.Trim();
            if(string.IsNullOrEmpty(searchString)){
                return;
            }
            
        }

        private void ReturnByOrder_Activated(object sender, EventArgs e)
        {
            search.Focus();
        }

        private void ReturnByOrder_Load(object sender, EventArgs e)
        {
            search.Focus();
        }

        private void okbutton_Click(object sender, EventArgs e)
        {

        }


    }
}
