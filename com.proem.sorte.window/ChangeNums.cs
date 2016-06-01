﻿using SorteSystem.com.proem.sorte.dao;
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
    public partial class ChangeNums : Form
    {
        private string goodsFileId;

        public ChangeNums()
        {
            InitializeComponent();
        }

        public ChangeNums(string goodsFileId)
        {
            InitializeComponent();
            this.goodsFileId = goodsFileId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                
            }
            else
            {
                int nums = Int32.Parse(textBox1.Text);
                sorteDao dao = new sorteDao();
                dao.updateNums(nums, goodsFileId);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void ChangeNums_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void ChangeNums_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void ChangeNums_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(this, EventArgs.Empty);
            }else if(e.KeyCode == Keys.Escape)
            {
                button2_Click(this, EventArgs.Empty);
            }
        }
    }
}