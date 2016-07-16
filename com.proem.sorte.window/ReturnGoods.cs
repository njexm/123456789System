using Branch;
using log4net;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.dao;
using sorteSystem.com.proem.sorte.domain;
using sorteSystem.com.proem.sorte.window.util;
using SorteSystem.com.proem.sorte.dao;
using SorteSystem.com.proem.sorte.domain;
using SpeechLib;
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
    public partial class ReturnGoods : Form
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(ReturnGoods));

        /// <summary>
        /// 退货亭点street
        /// </summary>
        private string returnStreet;

        /// <summary>
        /// 主界面
        /// </summary>
        private Main mainForm;

        public ReturnGoods()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="main"></param>
        public ReturnGoods(Main main)
        {
            InitializeComponent();
            this.mainForm = main;
        }

        /// <summary>
        /// 页面初始化加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnGoods_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();
        }

        /// <summary>
        /// 按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnGoods_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A){
                button2_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.Escape){
                button1_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.F1){
                BranchChoose choose = new BranchChoose(this);
                choose.Show();
            }
            if(textBox2.Focused && e.KeyCode == Keys.Enter){
                if(string.IsNullOrEmpty(returnStreet)){
                    MessageBox.Show("请先选择退货亭点,再进行扫码换货!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    AddGoods();
                    loadReturnGoods();
                }
                catch (Exception ex)
                {
                    log.Error("语音播报发生错误", ex);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (itemDataGird.DataSource == null || itemDataGird.RowCount == 0)
                {
                    return;
                }
                int index = itemDataGird.CurrentRow.Index;
                if (index > 0)
                {
                    itemDataGird.Rows[index - 1].Selected = true;
                    itemDataGird.CurrentCell = itemDataGird.Rows[index - 1].Cells[0];
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (itemDataGird.DataSource == null || itemDataGird.RowCount == 0)
                {
                    return;
                }
                int index = itemDataGird.CurrentRow.Index;
                if (index < itemDataGird.RowCount - 1)
                {
                    itemDataGird.Rows[index + 1].Selected = true;
                    itemDataGird.CurrentCell = itemDataGird.Rows[index + 1].Cells[0];
                }
            }
            else if(e.KeyCode == Keys.Delete){
                deleteSelect();
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                if (itemDataGird.DataSource == null || itemDataGird.RowCount == 0)
                {
                    return;
                }
                else
                {
                    bool isWeight = "1".Equals(itemDataGird.CurrentRow.Cells[6].Value.ToString()) ? true : false;
                    if (!isWeight)
                    {
                        string orderSorteId = itemDataGird.CurrentRow.Cells[6].Value.ToString();
                        float money = (itemDataGird.CurrentRow.Cells[3].Value == null || string.IsNullOrEmpty(itemDataGird.CurrentRow.Cells[3].Value.ToString())) ? 0F : float.Parse(itemDataGird.CurrentRow.Cells[3].Value.ToString());
                        ChangeNums changeNums = new ChangeNums(itemDataGird.CurrentRow.Cells[4].Value.ToString(), money, orderSorteId, this);
                        changeNums.Show();
                    }
                    else
                    {
                        MessageBox.Show("该商品为称重商品,无法进行手动数量修改!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void deleteSelect()
        {
            if (itemDataGird.DataSource == null || itemDataGird.RowCount == 0)
            {
                return;
            }
            string name = itemDataGird.CurrentRow.Cells[1].Value == null ? "" : itemDataGird.CurrentRow.Cells[1].Value.ToString();
            int index = itemDataGird.CurrentRow.Index;
            DialogResult dr = MessageBox.Show("确定删除" + name + "?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                orderDao orderDao = new orderDao();
                String orderSorteId = itemDataGird.CurrentRow.Cells[6].Value.ToString();
                orderSorte obj = orderDao.FindOrderSorteBy(orderSorteId);
                sorteDao sortedao = new sorteDao();
                
                orderDao.updateStoreHouse(obj);
                sortedao.DeleteBy(orderSorteId);
                loadTableAfterDelete(index);
            }
        }

        private void loadTableAfterDelete(int index)
        {
            String first = DateTime.Now.ToString("yyyy-MM-dd 00:00:01");
            String last = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            string sql = "select b.serialNumber, a.goods_name as goodsName, a.weight, a.money, b.id as goodsFileId, a.isWeight, a.id from zc_orders_sorte a left join zc_goods_master b on a.goods_id = b.id where 1=1 and isReturn ='1' and a.address='" + returnStreet + "' and a.createTime >= to_date('" + first + "', 'yyyy-MM-dd hh24:mi:ss') and a.createTime <=to_date('" + last + "', 'yyyy-MM-dd hh24:mi:ss')  order by a.createTime";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet dataset = new DataSet();
                da.Fill(dataset, "zc_orders_sorte");
                itemDataGird.AutoGenerateColumns = false;
                itemDataGird.DataSource = dataset;
                itemDataGird.DataMember = "zc_orders_sorte";
                if (itemDataGird.DataSource == null || itemDataGird.RowCount == 0)
                {

                }
                else
                {
                    if (itemDataGird.RowCount - 1 >= index)
                    {
                        itemDataGird.Rows[index].Selected = true;
                        itemDataGird.CurrentCell = itemDataGird.Rows[index].Cells[0];
                    }
                    else
                    {
                        itemDataGird.Rows[itemDataGird.RowCount - 1].Selected = true;
                        itemDataGird.CurrentCell = itemDataGird.Rows[itemDataGird.RowCount - 1].Cells[0];
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("加载扫码流水信息失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 扫码退货事件
        /// </summary>
        private void AddGoods()
        {
            SpeechVoiceSpeakFlags speakflag = SpeechVoiceSpeakFlags.SVSFlagsAsync;
            SpVoice voice = new SpVoice();
            string num = textBox2.Text;
            textBox2.Text = "";
            ///18位条码和13位条码混合
            if (string.IsNullOrEmpty(num) || (num.Length != 18 && num.Length != 13 && num.Length != 5))
            {

                voice.Speak("错误", speakflag);
                return;
            }
            string serialNumber = "";
            string money = "";
            string weight = "";
            bool isWeight = false;
            if (num.Length == 18)
            {
                serialNumber = num.Substring(2, 5);
            }
            else if (num.Length == 13 && num.StartsWith("28"))
            {
                serialNumber = num.Substring(2, 5);
            }
            else
            {
                serialNumber = num;
            }
            ZcGoodsMasterDao goodsMasterDao = new ZcGoodsMasterDao();
            ZcGoodsMaster zcGoodsMaster = goodsMasterDao.FindBySerialNumber(serialNumber);
            if (zcGoodsMaster == null)
            {
                voice.Speak("无商品", speakflag);
                return;
            }
            if (num.Length == 18)
            {

                if ("00001".Equals(num.Substring(12, 5)))
                {
                    weight = "1";
                    isWeight = false;
                }
                else
                {
                    weight = (float.Parse(num.Substring(7, 5).Insert(3, ".")) / zcGoodsMaster.GoodsPrice).ToString("0.0000");
                    isWeight = true;
                }
                money = float.Parse(num.Substring(7, 5).Insert(3, ".")).ToString();
            }
            else if (num.Length == 13 && num.StartsWith("28"))
            {
                ///现在是肉类
                //weight = float.Parse(num.Substring(7, 5).Insert(3, ".")).ToString("0.0000");
                weight = (float.Parse(num.Substring(7, 5).Insert(3, ".")) / zcGoodsMaster.GoodsPrice).ToString("0.0000");
                money = (zcGoodsMaster.GoodsPrice * float.Parse(weight)).ToString("0.00");
                isWeight = true;
            }
            else
            {
                weight = "1";
                isWeight = false;
                money = zcGoodsMaster.GoodsPrice.ToString("0.00");
            }
            orderSorte orderSorte = new orderSorte();
            orderSorte.createTime = DateTime.Now;
            orderSorte.updateTime = DateTime.Now;
            orderSorte.address = returnStreet;
            orderSorte.goods_id = zcGoodsMaster.Id;
            orderSorte.id = Guid.NewGuid().ToString();
            orderSorte.goods_name = zcGoodsMaster.GoodsName;
            orderSorte.sorteNum = "1";
            orderSorte.weight = weight;
            orderSorte.money = money;
            orderSorte.isWeight = isWeight ? "1" : "0";
            orderSorte.bar_code = num;
            orderSorte.isReturn = "1";
            sorteDao sortedao = new sorteDao();
            sortedao.addReturnGoods(orderSorte);
            //库存增加
            orderDao orderDao = new orderDao();
            orderDao.updateStoreHouseAdd(orderSorte);
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void ReturnGoods_Activated(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        /// <summary>
        /// 加载行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemDataGird_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //行号
            using (SolidBrush b = new SolidBrush(this.itemDataGird.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// 扫码框输入只能是数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 加载收银流水信息
        /// </summary>
        private void loadReturnGoods() {
            String first = DateTime.Now.ToString("yyyy-MM-dd 00:00:01");
            String last = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            string sql = "select b.serialNumber, a.goods_name as goodsName, a.weight, a.money, b.id as goodsFileId,a.isWeight, a.id from zc_orders_sorte a left join zc_goods_master b on a.goods_id = b.id where 1=1 and isReturn ='1' and a.address='" + returnStreet + "' and a.createTime >= to_date('" + first + "', 'yyyy-MM-dd hh24:mi:ss') and a.createTime <=to_date('" + last + "', 'yyyy-MM-dd hh24:mi:ss')  order by a.createTime";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da = null ;
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "zc_orders_sorte");
                this.itemDataGird.AutoGenerateColumns = false;
                this.itemDataGird.DataSource = ds;
                this.itemDataGird.DataMember = "zc_orders_sorte";
                //选中行保持在最后一个
                if (itemDataGird.RowCount - 1 >= 0)
                {
                    itemDataGird.Rows[itemDataGird.RowCount - 1].Selected = true;
                    itemDataGird.CurrentCell = itemDataGird.Rows[itemDataGird.RowCount - 1].Cells[0];
                }
            }
            catch (Exception ex)
            {
                log.Error("加载退货收银信息失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
        }


        public void setBranch(string street, string branchName)
        {
            textBox1.Text = branchName;
            returnStreet = street;
            loadReturnGoods();
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemDataGird_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 2){
                e.Value = Convert.ToDecimal(e.Value).ToString("0.0000");
            }
            else if (e.ColumnIndex == 3) {
                e.Value = Convert.ToDecimal(e.Value).ToString("0.00");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        public void reloadReturn()
        {
            loadReturnGoods();
        }
    }
}
