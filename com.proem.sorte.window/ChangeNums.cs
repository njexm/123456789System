﻿using sorteSystem.com.proem.sorte.dao;
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

        private SorteWithoutOrder sorteWithOutOrder;

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

        public ChangeNums(string goodsFileId, float money, string orderSorteId, SorteWithoutOrder obj)
        {
            InitializeComponent();
            this.goodsFileId = goodsFileId;
            this.money = money;
            this.sorteWithOutOrder = obj;
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
                if (textBox1.Text.Contains("."))
                {
                    if (textBox1.Text.IndexOf(".") == 0 || textBox1.Text.IndexOf(".") == textBox1.Text.Length - 1)
                    {
                        MessageBox.Show("请输入正确的重量!");
                        return;
                    }
                    else 
                    {
                        float weight = float.Parse(textBox1.Text);
                        sorteDao dao = new sorteDao();
                        ZcGoodsMasterDao goodsMasterDao = new ZcGoodsMasterDao();
                        ZcGoodsMaster master = goodsMasterDao.FindById(goodsFileId);
                        orderDao orderDao = new orderDao();
                        orderSorte orderSorte = orderDao.FindOrderSorteBy(orderSorteId);
                        float oldWeight = float.Parse(orderSorte.weight);
                        if (returnGoods != null)
                        {
                            dao.updateNums("-"+weight.ToString("0.0000"), goodsFileId, -weight * master.GoodsPrice, orderSorteId);
                        }else{
                            dao.updateNums(weight.ToString("0.0000"), goodsFileId, weight * master.GoodsPrice, orderSorteId);
                        }
                        if (sorteGoodList != null )
                        {
                            this.sorteGoodList.reLoadSaleTable();
                        }
                        else if (returnGoods != null)
                        {
                            this.returnGoods.reloadReturn();

                            if (-weight > oldWeight)
                            {
                                orderSorte.weight = (- oldWeight-weight).ToString("0.0000");
                                orderDao.updateStoreHouse(orderSorte);
                            }
                            else if (-weight < oldWeight)
                            {
                                orderSorte.weight = (oldWeight + weight).ToString("0.0000");
                                orderDao.updateStoreHouseAdd(orderSorte);
                            }

                            //orderSorte.goods_id = master.Id;
                            //orderSorte.sorteNum = "0";
                           // orderSorte.weight = weight.ToString("0.0000");
                           // orderDao.updateStoreHouse(orderSorte);
                        }
                        else
                        {
                            this.sorteWithOutOrder.reloadData();
                            //if (weight > oldWeight)
                            //{
                            //    orderSorte.weight = (weight - oldWeight).ToString("0.0000");
                            //    orderDao.updateStoreHouse(orderSorte);
                            //}
                            //else if(weight < oldWeight){
                            //    orderSorte.weight = (oldWeight - weight).ToString("0.0000");
                            //    orderDao.updateStoreHouseAddSorteWithOutOrder(orderSorte);
                            //}
                            //orderSorte.weight = weight.ToString("0.0000");
                           // orderDao.updateStoreHouseAddSorteWithOutOrder(orderSorte);
                            //orderDao.updateStoreHouseAdd(orderSorte);
                        }
                    }
                }
                else
                {
                    float nums = float.Parse(textBox1.Text);
                    sorteDao dao = new sorteDao();
                    ZcGoodsMasterDao goodsMasterDao = new ZcGoodsMasterDao();
                    ZcGoodsMaster master = goodsMasterDao.FindById(goodsFileId);
                    float oldnums = money / master.GoodsPrice;
                    if (returnGoods != null) {
                        dao.updateNums(-nums, goodsFileId, -nums * master.GoodsPrice, orderSorteId);
                    }
                    else 
                    {
                        dao.updateNums(nums, goodsFileId, nums * master.GoodsPrice, orderSorteId);
                    }
                    if (sorteGoodList != null )
                    {
                        this.sorteGoodList.reLoadSaleTable();
                    }
                    else if (returnGoods != null)
                    {
                        this.returnGoods.reloadReturn();
                        orderDao orderDao = new orderDao();
                        orderSorte orderSorte = orderDao.FindOrderSorteBy(orderSorteId);
                       // orderSorte.goods_id = master.Id;
                        if (oldnums + nums > 0)
                        {
                            orderSorte.weight = ( oldnums+ nums).ToString();
                            orderDao.updateStoreHouseAdd(orderSorte);
                        }
                        else if (oldnums + nums < 0)
                        {
                            orderSorte.weight = (-oldnums - nums).ToString();
                            orderDao.updateStoreHouse(orderSorte);
                        }

                        //orderSorte.sorteNum = (oldnums - nums).ToString();
                        //orderSorte.weight = orderSorte.sorteNum;
                        //orderDao.updateStoreHouse(orderSorte);
                    }
                    else
                    {
                        this.sorteWithOutOrder.reloadData();
                        //orderDao orderDao = new orderDao();
                        //orderSorte orderSorte = orderDao.FindOrderSorteBy(orderSorteId);
                        ////orderSorte.goods_id = master.Id;
                        //if(oldnums - nums > 0){
                        //    orderSorte.weight = (oldnums - nums).ToString();
                        //    orderDao.updateStoreHouseAddSorteWithOutOrder(orderSorte);
                        //}else if(oldnums-nums < 0){
                        //    orderSorte.weight = (nums - oldnums).ToString();
                        //    orderDao.updateStoreHouse(orderSorte);
                        //}
                        //orderSorte.sorteNum = (oldnums - nums).ToString();
                        //orderSorte.weight = orderSorte.sorteNum;
                        //orderDao.updateStoreHouseAddSorteWithOutOrder(orderSorte);
                        //orderDao.updateStoreHouseAdd(orderSorte);
                    }
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
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 13 && e.KeyChar != 46)
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
