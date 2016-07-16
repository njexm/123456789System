using sorteSystem.com.proem.sorte.dao;
using sorteSystem.com.proem.sorte.domain;
using SorteSystem.com.proem.sorte.dao;
using SorteSystem.com.proem.sorte.domain;
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

        private float money;

        private string orderSorteId;

        private sorteGoodList sorteGoodList;

        private ReturnGoods returnGoods;

        public ChangeNums()
        {
            InitializeComponent();
        }

        public ChangeNums(string goodsFileId, float money, string orderSorteId ,sorteGoodList obj)
        {
            InitializeComponent();
            this.goodsFileId = goodsFileId;
            this.money = money;
            this.sorteGoodList = obj;
            this.orderSorteId = orderSorteId;
        }

        public ChangeNums(string goodsFileId, float money, string orderSorteId, ReturnGoods obj)
        {
            InitializeComponent();
            this.goodsFileId = goodsFileId;
            this.money = money;
            this.returnGoods = obj;
            this.orderSorteId = orderSorteId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                
            }
            else
            {
                float nums = Int32.Parse(textBox1.Text);
                sorteDao dao = new sorteDao();
                ZcGoodsMasterDao goodsMasterDao = new ZcGoodsMasterDao();
                ZcGoodsMaster master = goodsMasterDao.FindById(goodsFileId);
                float oldnums = money / master.GoodsPrice;
                dao.updateNums(nums, goodsFileId, nums * master.GoodsPrice, orderSorteId);
                if (sorteGoodList != null && returnGoods == null)
                {
                    this.sorteGoodList.reLoadSaleTable();
                }
                else {
                    this.returnGoods.reloadReturn();
                    orderDao orderDao = new orderDao();
                    orderSorte orderSorte = new orderSorte();
                    orderSorte.goods_id = master.Id;
                    orderSorte.sorteNum = (oldnums - nums).ToString();
                    orderSorte.weight = orderSorte.sorteNum;
                    orderDao.updateStoreHouse(orderSorte);
                }
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
