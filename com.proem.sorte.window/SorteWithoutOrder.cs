using Branch;
using log4net;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.dao;
using sorteSystem.com.proem.sorte.domain;
using sorteSystem.com.proem.sorte.util;
using sorteSystem.com.proem.sorte.window.util;
using SorteSystem.com.proem.sorte.dao;
using SorteSystem.com.proem.sorte.domain;
using SpeechLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sorteSystem.com.proem.sorte.window
{
    public partial class SorteWithoutOrder : Form
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(SorteWithoutOrder));

        /// <summary>
        /// 分店编号
        /// </summary>
        private string street;

        /// <summary>
        /// 分店id
        /// </summary>
        private string branchTotalId;

        /// <summary>
        /// 主界面
        /// </summary>
        private Main mainForm;

        public SorteWithoutOrder()
        {
            InitializeComponent();
        }

        public SorteWithoutOrder(Main obj)
        {
            InitializeComponent();
            mainForm = obj;
        }

        /// <summary>
        /// 退出按钮
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

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        /// <summary>
        /// 按键事件绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SorteWithoutOrder_KeyDown(object sender, KeyEventArgs e)
        {
            ///返回
            if(e.KeyCode == Keys.A){
                button2_Click(this, EventArgs.Empty);
            }
            ///退出
            if(e.KeyCode == Keys.Escape){
                button1_Click(this, EventArgs.Empty);
            }
            ///打印
            if(e.KeyCode == Keys.D){
                button3_Click(this, EventArgs.Empty);
            }
            ///选择亭点
            if(e.KeyCode == Keys.F1){
                BranchChoose choose = new BranchChoose(this);
                choose.Show();
            }
            ///扫码
            if (textBox2.Focused && e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(street))
                {
                    MessageBox.Show("请先选择亭点,再进行扫码收银!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = "";
                    return;
                }
                try
                {
                    AddGoods();
                    loadSorteGoods();
                }
                catch (Exception ex)
                {
                    log.Error("语音播报发生错误", ex);
                }
            }
            else if (e.KeyCode == Keys.Up)   ///向上键
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
            else if (e.KeyCode == Keys.Down)    ///向下键
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
            ///删除选中的
            else if (e.KeyCode == Keys.Delete)
            {
                deleteSelect();
            }
            ///修改数量或者重量
            else if (e.KeyCode == Keys.Multiply) 
            {
                if (itemDataGird.DataSource == null || itemDataGird.RowCount == 0)
                {
                    return;
                }
                else
                {
                    bool isWeight = "1".Equals(itemDataGird.CurrentRow.Cells[5].Value.ToString()) ? true : false;
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

        /// <summary>
        /// 删除
        /// </summary>
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

                //库存添加
                //orderDao.updateStoreHouseAddSorteWithOutOrder(obj);
                sortedao.DeleteBy(orderSorteId);
                loadTableAfterDelete(index);
            }
        }

        private void loadTableAfterDelete(int index)
        {
            String first = DateTime.Now.ToString("yyyy-MM-dd 00:00:01");
            String last = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            string sql = "select b.serialNumber, a.goods_name as goodsName, a.weight, a.money, b.id as goodsFileId,a.isWeight, a.id from zc_orders_sorte a left join zc_goods_master b on a.goods_id = b.id where 1=1 and a.isReturn ='0' and a.isPrint='0' and a.sorteId is null and a.address='" + street + "' and a.createTime >= to_date('" + first + "', 'yyyy-MM-dd hh24:mi:ss') and a.createTime <=to_date('" + last + "', 'yyyy-MM-dd hh24:mi:ss')  order by a.createTime";
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
        /// 扫码添加
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
                MessageFail fail = new MessageFail();
                fail.Show();
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
            //ZcGoodsMasterDao goodsMasterDao = new ZcGoodsMasterDao();
            //ZcGoodsMaster zcGoodsMaster = goodsMasterDao.FindBySerialNumber(serialNumber);
            ZcGoodsMaster zcGoodsMaster = ConstantUtil.getGoodsBySerialNumber(serialNumber);
            if (zcGoodsMaster == null)
            {
                voice.Speak("无商品", speakflag);
                MessageFail fail = new MessageFail();
                fail.Show();
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
            orderSorte.address = street;
            orderSorte.goods_id = zcGoodsMaster.Id;
            orderSorte.id = Guid.NewGuid().ToString();
            orderSorte.goods_name = zcGoodsMaster.GoodsName;
            orderSorte.sorteNum = "1";
            orderSorte.weight = weight;
            orderSorte.money = money;
            orderSorte.isWeight = isWeight ? "1" : "0";
            orderSorte.bar_code = num;
            orderSorte.isReturn = "0";
            orderSorte.isPrint = "0";
            orderSorte.goodsPrice = zcGoodsMaster.GoodsPrice.ToString();
            orderSorte.costPrice = zcGoodsMaster.costPrice;
            orderSorte.rate = zcGoodsMaster.OutTax.ToString();
            orderDao orderDao = new orderDao();
            //orderSorte.costPrice = orderDao.getCostPrice(zcGoodsMaster.Id, false, float.Parse(weight)).ToString();
            sorteDao sortedao = new sorteDao();
            sortedao.addSorteWithOutGoods(orderSorte);
            //库存减少
            //orderDao.updateStoreHouse(orderSorte);
        }

        /// <summary>
        /// 行号绑定
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
        /// 格式化显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemDataGird_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("0.0000");
            }
            else if (e.ColumnIndex == 3)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("0.00");
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (itemDataGird.DataSource == null || itemDataGird.RowCount == 0)
            {
                return;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < itemDataGird.RowCount; i++ )
            {
                string id = itemDataGird[6, i].Value != null ? itemDataGird[6, i].Value.ToString() : "";
                list.Add(id);
            }
            //打印
            printTicket();
            
            orderDao orderDao = new orderDao();
            ZcGoodsMasterDao zcGoodsMasterDao = new ZcGoodsMasterDao();
            DispatchingDao dispatchDao = new DispatchingDao();

            //生成配送出库单
            int dispatchingCount = orderDao.getDispatchingCount();
            DispatchingWarehouse dispatchingWarehouse = new DispatchingWarehouse();
            dispatchingWarehouse.id = Guid.NewGuid().ToString();
            dispatchingWarehouse.createTime = DateTime.Now;
            dispatchingWarehouse.updateTime = DateTime.Now;
            dispatchingWarehouse.street = street;
            dispatchingWarehouse.dispatcher_date = DateTime.Now;
            dispatchingWarehouse.dispatcherOdd = "DO0001" + DateTime.Now.ToString("yyyyMMdd") + (dispatchingCount + 1).ToString().PadLeft(4, '0');
            dispatchingWarehouse.type = "2";
            dispatchingWarehouse.statue = 2;
            dispatchingWarehouse.branch_id = ConstantUtil.BranchId;
            dispatchingWarehouse.branch_total_id = branchTotalId;
            List<DispatchingWarehouseItem> itemList = new List<DispatchingWarehouseItem>();
            float nums = 0;
            float money = 0;
            float weight = 0;
            for (int i = 0; i < list.Count; i++ )
            {
                orderSorte orderSorte = orderDao.FindOrderSorteBy(list[i]);
                //库存减少
                orderDao.updateStoreHouse(orderSorte);

                //打印状态修改
                orderDao.updateIsPrint(orderSorte.id);

                DispatchingWarehouseItem item = new DispatchingWarehouseItem();
                item.id = Guid.NewGuid().ToString();
                item.createTime = DateTime.Now;
                item.updateTime = DateTime.Now;
                item.cash_date = DateTime.Now;
                item.dispatchingWarehouseId = dispatchingWarehouse.id;
                ZcGoodsMaster goodsFile = zcGoodsMasterDao.FindById(orderSorte.goods_id);
                item.goods_name = goodsFile.GoodsName;
                item.goodsPrice = goodsFile.GoodsPrice.ToString();
                item.goods_specifications = goodsFile.GoodsSpecifications;
                item.nums = orderSorte.sorteNum;
                item.serialNumber = goodsFile.SerialNumber;
                item.money = orderSorte.money;
                item.weight = orderSorte.weight;
                item.branch_total_id = branchTotalId;
                item.goodsFile_id = orderSorte.goods_id;
                item.costPrice = orderSorte.costPrice;
                item.rate = orderSorte.rate;
                item.rateMoney = (float.Parse(orderSorte.money) * float.Parse(orderSorte.rate) / (1 + float.Parse(orderSorte.rate))).ToString();
                itemList.Add(item);
                nums += string.IsNullOrEmpty(item.nums) ? 0 : float.Parse(item.nums);
                money += string.IsNullOrEmpty(item.money) ? 0 : float.Parse(item.money);
                weight += string.IsNullOrEmpty(item.weight) ? 0 : float.Parse(item.weight);
            }
            dispatchingWarehouse.nums = nums.ToString();
            dispatchingWarehouse.money = money.ToString();
            dispatchingWarehouse.weight = weight.ToString();

            dispatchDao.addList(itemList);
            if (itemList.Count != 0)
            {
                dispatchDao.addObj(dispatchingWarehouse);
            }
            orderDao.insertLog("生成了一条配送出库单", "配送出库单");

            BranchSettlementItem branchSettlementItem = new BranchSettlementItem();
            branchSettlementItem.id = Guid.NewGuid().ToString();
            branchSettlementItem.createTime = DateTime.Now;
            branchSettlementItem.updateTime = DateTime.Now;
            branchSettlementItem.payableMoney = dispatchingWarehouse.money;
            branchSettlementItem.actualMoney = "0.00";
            branchSettlementItem.discountMoney = "0.00";
            branchSettlementItem.favorableMoney = "0.00";
            branchSettlementItem.paidMoney = "0.00";
            branchSettlementItem.tax = "0.00";
            branchSettlementItem.codeType = "配送出库单";
            branchSettlementItem.billDate = dispatchingWarehouse.createTime;

            branchSettlementItem.agreedTime = DateTime.Now.AddMonths(1);
            branchSettlementItem.unpaidMoney = branchSettlementItem.payableMoney;
            branchSettlementItem.code = dispatchingWarehouse.dispatcherOdd;
            branchSettlementItem.money = "0";
            branchSettlementItem.branchCode = dispatchingWarehouse.street;

            orderDao.addBranchSettlementItem(branchSettlementItem);

            orderDao.insertLog("生成缴款单", "缴款单");

            //生成分拣单
            Sorte sorte = new Sorte();
            sorte.Id = Guid.NewGuid().ToString();
            sorte.createTime = DateTime.Now;
            sorte.updateTime = DateTime.Now;
            sorte.auditStatus = 4;
            int sorteCount = orderDao.getSorteCount();
            sorte.code = "FJ0001" + DateTime.Now.ToString("yyyyMMdd") + (sorteCount + 1).ToString().PadLeft(4, '0');
            sorte.makeTime = DateTime.Now;
            sorte.sortingMethod = "按分店分拣";
            //sorte.makeMen = "";
            sorte.groupFlag = 1;

            orderDao.addSorte(sorte);

            SorteItem sorteItem = new SorteItem();
            sorteItem.id = Guid.NewGuid().ToString();
            sorteItem.createTime = DateTime.Now;
            sorteItem.updateTime = DateTime.Now;
            sorteItem.areaId = street;
            sorteItem.sortStatus = "1";
            //sorteItem.address = ;
            sorteItem.branch_total_id = branchTotalId;
            //sorteItem.customer = ;
            sorteItem.sorte_id = sorte.Id;

            orderDao.addSorteItem(sorteItem);
            orderDao.insertLog("生成并完成了一条分拣单", "分拣单");
            //重新加载数据
            loadSorteGoods();
        }



        /// <summary>
        /// 选择分拣亭点
        /// </summary>
        /// <param name="street"></param>
        /// <param name="branchName"></param>
        public void setBranch(string street, string branchName, string branchId)
        {
            textBox1.Text = branchName;
            this.street = street;
            this.branchTotalId = branchId;
            ///重新选择street后加载数据
            loadSorteGoods();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void loadSorteGoods()
        {
            String first = DateTime.Now.ToString("yyyy-MM-dd 00:00:01");
            String last = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            string sql = "select b.serialNumber, a.goods_name as goodsName, a.weight, a.money, b.id as goodsFileId,a.isWeight, a.id from zc_orders_sorte a left join zc_goods_master b on a.goods_id = b.id where 1=1 and a.isReturn ='0' and a.sorteId is null and a.isPrint='0' and a.address='" + street + "' and a.createTime >= to_date('" + first + "', 'yyyy-MM-dd hh24:mi:ss') and a.createTime <=to_date('" + last + "', 'yyyy-MM-dd hh24:mi:ss')  order by a.createTime";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da = null;
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
                log.Error("加载直接收银信息失败", ex);
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
        /// 窗口激活
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SorteWithoutOrder_Activated(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        /// <summary>
        /// 焦点始终在输入框内
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SorteWithoutOrder_Load(object sender, EventArgs e)
        {
            ///输入框获取焦点
            textBox2.Focus();
            ///时间运行
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();
        }


        public void printTicket()
        {
            strs = GetPrintStr();

            PrintDocument pd = new PrintDocument();

            PrintController printController = new StandardPrintController();
            pd.PrintController = printController;
            //设置边距

            Margins margin = new Margins(20, 20, 20, 20);

            pd.DefaultPageSettings.Margins = margin;
            ////纸张设置默认

            //打印事件设置            
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            try
            {
                // ppd.Document = pd;

                //ppd.ShowDialog();
                pd.Print();
                ///打印完成后再进行初始化数据
            }

            catch (Exception ex)
            {

                log.Error("打印出错，检查打印机是否连通", ex);
                MessageBox.Show("收银成功,打印出错,请检查打印机是否正确连接!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }

        private int getYc(double cm)
        {

            return (int)(cm / 25.4) * 100;

        }

        public string[] GetPrintStr()
        {
            orderDao sortedao = new orderDao();
            String branchName = sortedao.getBranchName(street);

            StringBuilder sb = new StringBuilder();

            string tou = "宜鲜美配送有限公司收银单据";

            string address = "南京市江宁区东麒路66号";

            sb.Append("            " + tou + "     \n");

            sb.Append("-----------------------------------------------------------------\n");

            sb.Append("日期:" + DateTime.Now.ToShortDateString() + "  " + "分店:" + branchName + "\n");

            sb.Append("-----------------------------------------------------------------\n");

            sb.Append("品名" + "\t\t" + "单价" + "\t" + "重/数量" + "\t" + "小计" + "\n");
            float totalSum = 0;
            float totalAmount = 0;
            string first = DateTime.Now.ToString("yyyy-MM-dd 00:00:01");
            string last = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            string sql = "select a.goods_id, a.goods_name, a.SORTENUM, a.WEIGHT, b.GOODS_PRICE, b.GOODS_UNIT,a.money from ZC_ORDERS_SORTE a left join ZC_GOODS_MASTER b "
                + " on a.GOODS_ID = b.SERIALNUMBER where a.ADDRESS = :street and a.isReturn='0' and a.isPrint ='0' and a.sorteId is null and a.createTime>=to_date('" + first + "', 'yyyy-MM-dd HH24:mi:ss') and a.createTime<=to_date('" + last + "', 'yyyy-MM-dd HH24:mi:ss') order by b.serialnumber ";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":street", street);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string serialNumber = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    string name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    name = name.Trim();
                    string sorteNum = reader.IsDBNull(2) ? "0" : reader.GetString(2);
                    string weightString = reader.IsDBNull(3) ? "0" : reader.GetString(3);
                    string goodsPrice = reader.IsDBNull(4) ? "0" : reader.GetFloat(4).ToString("0.00");
                    string unit = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                    string goodsMoney = reader.IsDBNull(6) ? "0" : reader.GetString(6);
                    float weight = float.Parse(weightString);
                    float price = float.Parse(goodsPrice);
                    float nums = float.Parse(sorteNum);
                    float money = float.Parse(goodsMoney);
                    totalSum += nums;
                    totalAmount += money;
                    //Console.WriteLine(name + "------>"+name.Length);
                    if (name.Length < 4)
                    {
                        name += "\t\t";
                    }
                    else if (name.Length <= 6)
                    {
                        name += "\t";
                    }
                    else
                    {
                        name = name.Substring(0, 6) + "...\t";
                    }
                    if (serialNumber.Length == 5)
                    {
                        sb.Append(name + price.ToString("0.00") + "\t" + weight.ToString("0.000") + "\t" + money.ToString("0.00") + "\n");
                    }
                    else
                    {
                        sb.Append(name + price.ToString("0.00") + "\t" + sorteNum + unit + "\t" + money.ToString("0.00") + "\n");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
            finally
            {
                cmd.Dispose();
                if (conn != null)
                {
                    conn.Close();
                }
            }
            sb.Append("-----------------------------------------------------------------\n");

            sb.Append("数量: " + totalSum.ToString("0.00") + "\t\t 合计: " + totalAmount.ToString("0.00") + "\n");

            sb.Append("-----------------------------------------------------------------\n");

            sb.Append("地址：" + address + "\n");


            sb.Append("             谢谢惠顾欢迎下次光临                ");
            Console.WriteLine(sb.ToString());
            return sb.ToString().Split('\n');

        }

        private int index;

        private string[] strs;

        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font InvoiceFont = new Font("Arial", 10, FontStyle.Regular);
            SolidBrush GrayBrush = new SolidBrush(Color.Black);
            //string[] strs = GetPrintStr();
            int y = 0;
            while (index < strs.Length)
            {
                g.DrawString(strs[index++], InvoiceFont, GrayBrush, 0, y);
                y += 15;
                if (y > e.PageBounds.Height-30)
                {
                    e.HasMorePages = true;
                    return;
                }

            }
            index = 0;
            e.HasMorePages = false;
        }

        public void reloadData()
        {
            loadSorteGoods();
        }
    }
}
