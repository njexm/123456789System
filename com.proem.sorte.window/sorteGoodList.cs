using Branch;
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
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using System.Globalization;

namespace sorteSystem.com.proem.sorte.window
{
    public partial class sorteGoodList : Form
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(sorteGoodList));

        private delegate string updateGVDelegate();

        private delegate void endSorteDelegate();

        /// <summary>
        /// 是否处于扫码datagridview
        /// </summary>
        private bool isResale = true;

        private int select_value = 0;

        public void setSelectValue()
        {
            select_value = 0;
        }

        private int RowsCount = 0;

        private string updateGV()
        {
            //if(!isResale){
            
            
                DataSet ds = getGridData();
                goodDataGridView.DataSource = ds;
                goodDataGridView.CurrentCell = null;

                if (RowsCount != goodDataGridView.Rows.Count)
                {
                    RowsCount = goodDataGridView.Rows.Count;
                    select_value = 0;
                }
                if (goodDataGridView.Rows.Count > select_value)
                {
                    goodDataGridView.Rows[select_value].Selected = true;
                    goodDataGridView.CurrentCell = goodDataGridView.Rows[select_value].Cells[0];
                }

            
                color();
               // }
            return "1";
        }

        public sorteGoodList()
        {
            InitializeComponent();

        }

        private sorteList sorteListForm;

        public sorteGoodList(sorteList obj)
        {
            InitializeComponent();
            sorteListForm = obj;
        }

        private void goodDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
        }

        private void goodTableGroupBox_Enter(object sender, EventArgs e)
        {

        }
        public Boolean sortFlag = false;
        DataTable dt;
        orderDao sortedao;
        string branchName;
        object result;
        private DataSet ds = null;

        private bool isFirst = true;


        private void sorteGoodList_Load(object sender, EventArgs e)
        {
            numberTextBox.Focus();
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();

            int hw = redButton.Height;
            if (hw > redButton.Width) hw = redButton.Width;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(4, 4, hw - 8, hw - 8);
            gp.FillMode = System.Drawing.Drawing2D.FillMode.Winding;
            redButton.Region = new Region(gp);
            redButton.BackColor = Color.Red;
            yellowButton.Region = new Region(gp);
            yellowButton.BackColor = Color.Yellow;
            greenButton.Region = new Region(gp);
            greenButton.BackColor = Color.Green;
            //---
            dt = ConstantUtil.Branchds.Tables["Zc_sorte_item"];
            result = dt.Rows[ConstantUtil.index][14];
            textBox2.Text = dt.Rows[ConstantUtil.index][9].ToString();
            sortedao = new orderDao();
            branchName = sortedao.getBranchName(result.ToString());
            textBox1.Text = branchName;

            //展示数据
            showInfo();

            //后台刷新数据
            System.Timers.Timer pTimer = new System.Timers.Timer(1000);//每隔5秒执行一次，没用winfrom自带的
            pTimer.Elapsed += new System.Timers.ElapsedEventHandler(pTimer_Elapsed);//委托，要执行的方法
            pTimer.AutoReset = true;//获取该定时器自动执行
            pTimer.Enabled = true;//这个一定要写，要不然定时器不会执行的
            Control.CheckForIllegalCrossThreadCalls = false;//这个不太懂，有待研究


            ///初始化datagridview显示
            salepanel.Show();
            loadSaleTable();
            goodTablePanel.Hide();
        }

        public DataSet getGridData()
        {
            result = dt.Rows[ConstantUtil.index][14];
            string remark = dt.Rows[ConstantUtil.index][9].ToString().Trim();
            if (string.IsNullOrEmpty(remark))
            {
                messagePanel.Visible = false;
                if(isResale){
                    salepanel.Location = new Point(3, 117);
                }else{
                    goodTablePanel.Location = new Point(3, 117);
                }
               
                textBox2.Text = "";
            }
            else
            {
                messagePanel.Visible = true;
                if(isResale)
                {
                    salepanel.Location = new Point(3, 185);
                }else
                {
                    goodTablePanel.Location = new Point(3, 185);
                }
                
                textBox2.Text = remark;
            }
            sortedao = new orderDao();
            branchName = sortedao.getBranchName(result.ToString());
            textBox1.Text = branchName;
            OracleConnection connection = null;
            try
            {
                connection = OracleUtil.OpenConn();
                if (connection == null)
                {
                    ds = null;

                }
                else
                {
                    //在每次查找或填充数据前判断ds是否为null
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            ds.Tables[0].Rows.Clear();
                            ds.Tables[0].Columns.Clear();
                            ds.Tables[0].AcceptChanges();
                        }
                    }
                    else
                    {
                        ds = new DataSet();
                    }
                    string sql = "select name,serialNumber,goodsfile_id,sum(nums) as nums,branchid ,sorteNum ,workname,workcode from "
                                + "(select a.goods_state,a.name,a.nums,c.id as goodsfile_id,c.serialNumber,b.branchid,d.sortenum,e.workname,e.workcode "
                                + " from zc_order_process_item a "
                                + " left join zc_order_process b on b.id=a.order_id left join zc_goods_master c on c.id=a.goodsfile_id left join (select SUM(sortenum) as sortenum,goods_id ,address from ZC_ORDERS_SORTE where sorteId = '" + ConstantUtil.sorte_id + "' GROUP by goods_id, address) d on d.goods_id = c.id and b.branchid=d.address  left join zc_workstation e on e.id = c.zcuserinfo"
                                + " where branchid = '" + result + "' ) "
                                + "group by name,serialNumber,goodsfile_id,branchid,sorteNum,workname,workcode order by serialNumber";
                    OracleCommand cmd = new OracleCommand(sql, connection);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Zc_sorte_item");
                }

            }
            catch (Exception ex)
            {
                log.Error("加载各分店商品信息失败", ex);
            }
            finally
            { 
                if(connection != null){
                    connection.Close();
                }
            }
            return ds;
        }

        public void showInfo()
        {
            if (ConstantUtil.redStatus == 3)
            {
                greenButton.Hide();
                greenLabel.Hide();
                yellowButton.Hide();
                yellowLabel.Hide();
                redButton.Show();
                redLabel.Show();
            }
            else
            {
                greenButton.Hide();
                greenLabel.Hide();
                yellowButton.Show();
                yellowLabel.Show();
                redButton.Hide();
                redLabel.Hide();
            }

            getGridData();
            goodDataGridView.DataSource = ds;
            goodDataGridView.AutoGenerateColumns = false;
            goodDataGridView.DataMember = "Zc_sorte_item";

            color();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //ConstantUtil.sortelist.Show();
            this.sorteListForm.Show();
            this.Hide();
        }

        private void leaveButton_Click(object sender, EventArgs e)
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

        private void startButton_Click(object sender, EventArgs e)
        {

            DataTable dt = ConstantUtil.Branchds.Tables["Zc_sorte_item"];
            object result = dt.Rows[ConstantUtil.index][14];
            //byte[] buffer = Encoding.Default.GetBytes(result.ToString());
            orderDao orderdao = new orderDao();
            if (ConstantUtil.ipList == null || ConstantUtil.ipList.Count == 0)
            {
                MessageBox.Show("工位或者工位IP尚未设定，请设定完毕后再开始分拣");
                return;
            }
            else
            {
                for(int i= 0; i < ConstantUtil.ipList.Count; i++)
                {
                    string ip = ConstantUtil.ipList[i];
                    orderdao.insertSorteStatus(result.ToString(), ip);
                }
            }
            redButton.Hide();
            redLabel.Hide();
            greenButton.Show();
            greenLabel.Show();
            yellowButton.Hide();
            yellowLabel.Hide();
            numberTextBox.Focus();
            //if (ConstantUtil.socketList.Count > 0)
            //{
            //    orderDao orderdao = new orderDao();
            //    orderdao.insertSorteStatus(result.ToString(),ConstantUtil.ip1);
            //    orderdao.insertSorteStatus(result.ToString(), ConstantUtil.ip2);
            //    redButton.Hide();
            //        redLabel.Hide();
            //        greenButton.Show();
            //        greenLabel.Show();
            //        yellowButton.Hide();
            //        yellowLabel.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("目前未有子设备连接主机!");
            //}

            //byte[] buffer = Encoding.Default.GetBytes(str);
            //connSocket.Send(buffer, buffer.Length, SocketFlags.None);
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextbutton_Click(object sender, EventArgs e)
        {
           
            //bool printFlag = false;
            //if (goodDataGridView.Rows.Count > 0)
            //{
            //    for (int i = 0; i < goodDataGridView.Rows.Count; i++)
            //    {
            //        string oldCount = goodDataGridView.Rows[i].Cells[3].Value == null ? "" : goodDataGridView.Rows[i].Cells[3].Value.ToString();
            //        string newCount = goodDataGridView.Rows[i].Cells[4].Value == null ? "" : goodDataGridView.Rows[i].Cells[4].Value.ToString();
            //        if (oldCount.Equals(newCount)) { }
            //        else
            //        {
            //            //MessageBox.Show("存在分拣份数不符合的商品，请检测", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            printFlag = true;
            //            break;
            //            //return;
            //        }
            //    }
            //}
            //string messageString = "";
            //if (printFlag)
            //{
            //    messageString = "存在分拣份数不符合的商品,请检查,是否打印?";
            //}
            //else 
            //{
            //    messageString = "是否打印?";
            //}

            ////新增打印  2016-3-24 start
            //DialogResult dr = MessageBox.Show(messageString, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            //    //打印操作

                
            //}
            //else { }

            printTicket();
            //end

            //初始化
            //_ScrollValue = 0;
            RowsCount = 0;
            select_value = 0;
            isFirst = true;

            if (ConstantUtil.index + 1 >= dt.Rows.Count)
            {
                DialogResult dr = MessageBox.Show("已分拣完最后一个亭点，是否结束分拣?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if(dr == DialogResult.OK){
                    endButton_Click(this, EventArgs.Empty);
                }
            }
            else
            {
                ConstantUtil.index = ConstantUtil.index + 1;
                ConstantUtil.street = dt.Rows[ConstantUtil.index][14].ToString();
                startButton_Click(this, EventArgs.Empty);
                loadSaleTable();
            }
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            int status = getSorteStatus();
            if(status == 4){
                MessageBox.Show("分拣单已完成，无法重复进行结束分拣!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (sortFlag == false)
            {
                DataTable dt = ConstantUtil.Branchds.Tables["Zc_sorte_item"];
                object sorteId = dt.Rows[0][8];
                if (ConstantUtil.index + 1 >= dt.Rows.Count)
                {
                    for (int i = 0; i < goodDataGridView.Rows.Count; i++)
                    {
                        string oldCount = goodDataGridView.Rows[i].Cells[3].Value == null ? "" : goodDataGridView.Rows[i].Cells[3].Value.ToString();
                        string newCount = goodDataGridView.Rows[i].Cells[4].Value == null ? "" : goodDataGridView.Rows[i].Cells[4].Value.ToString();
                        if (oldCount.Equals(newCount)) { }
                        else
                        {
                            DialogResult dr = MessageBox.Show("存在分拣份数不符合的商品，确定结束分拣?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (dr == DialogResult.OK)
                            {
                                break;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                     sorteDao sorteDao = new sorteDao();
                     ZcGoodsMasterDao zcGoodsMasterDao = new ZcGoodsMasterDao();
                     DispatchingDao dispatchDao = new DispatchingDao();
                    endSorteDelegate endDelegate = endSorte;
                    this.BeginInvoke(endDelegate);
                    Thread objThread = new Thread(new ThreadStart(delegate
                    {
                        orderDao orderdao = new orderDao();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            object id = dt.Rows[i][0];
                            object streetId = dt.Rows[i][14];
                            List<ZcProcessOrder> ZcProcessOrderList = orderdao.FindAll(streetId.ToString());
                            if (ZcProcessOrderList != null && ZcProcessOrderList.Count() > 0)
                            {
                                for (int a = 0; a < ZcProcessOrderList.Count; a++)
                                {
                                    ZcProcessOrder zcprocessOrder = ZcProcessOrderList[a];
                                    string orderId = zcprocessOrder.id;
                                    List<ZcProcessOrderItem> ZcProcessOrderItemList = orderdao.getItemByid(orderId);
                                    if (ZcProcessOrderItemList != null && ZcProcessOrderItemList.Count() > 0)
                                    {
                                        orderdao.AddtransitItem(ZcProcessOrderItemList);
                                        for (int b = 0; b < ZcProcessOrderItemList.Count; b++)
                                        {
                                            ZcProcessOrderItem zcProcessOrderItem = ZcProcessOrderItemList[b];
                                            string itemId = zcProcessOrderItem.id;
                                            orderdao.deletePorcessItem(itemId);
                                            //orderdao.updateStoreHouse(zcProcessOrderItem);
                                        }
                                    }
                                    if ("全部完成".Equals(zcprocessOrder.pullFlag))
                                    {
                                        zcprocessOrder.orderStatus = "5";
                                        orderdao.deletePorcessOrder(zcprocessOrder.id);
                                        int count = orderdao.getTransitOrderCount(zcprocessOrder.id);

                                        if (count == 0)
                                        {
                                            orderdao.AddtransitOrder(zcprocessOrder);
                                        }
                                        else
                                        {

                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                
                            }
                            orderdao.deleteAllSorteStatus();
                            DispatchingWarehouse dispatchingWarehouse = new DispatchingWarehouse();
                            dispatchingWarehouse.id = Guid.NewGuid().ToString();
                            dispatchingWarehouse.createTime = DateTime.Now;
                            dispatchingWarehouse.updateTime = DateTime.Now;
                            dispatchingWarehouse.street = streetId.ToString();
                            dispatchingWarehouse.dispatcher_date = DateTime.Now;
                            dispatchingWarehouse.dispatcherOdd = "PSCKD"+DateTime.Now.ToString("yyyyMMddHHmmss");
                            dispatchingWarehouse.type = "2"; 
                            dispatchingWarehouse.statue = 2;
                            dispatchingWarehouse.branch_id = ConstantUtil.BranchId;
                            dispatchingWarehouse.branch_total_id = dt.Rows[i][6].ToString();

                            float nums = 0;
                            float money = 0;
                            float weight = 0;
                            List<orderSorte> sorteList = sortedao.getByStreet(streetId.ToString());
                            List<DispatchingWarehouseItem> itemList = new List<DispatchingWarehouseItem>();
                            for (int j = 0; j < sorteList.Count; j++ )
                            {
                                orderSorte obj = sorteList[j];
                                DispatchingWarehouseItem item = new DispatchingWarehouseItem();
                                item.id = Guid.NewGuid().ToString();
                                item.createTime = DateTime.Now;
                                item.updateTime = DateTime.Now;
                                item.cash_date = DateTime.Now;
                                item.dispatchingWarehouseId = dispatchingWarehouse.id;
                                ZcGoodsMaster goodsFile = zcGoodsMasterDao.FindById(obj.goods_id);
                                item.goods_name = goodsFile.GoodsName;
                                item.goodsPrice = goodsFile.GoodsPrice.ToString();
                                item.goods_specifications = goodsFile.GoodsSpecifications;
                                item.nums = obj.sorteNum;
                                item.serialNumber = goodsFile.SerialNumber;
                                item.money = obj.money;
                                item.weight = obj.weight;
                                item.branch_total_id = dt.Rows[i][6].ToString();
                                item.goodsFile_id = obj.goods_id;
                                itemList.Add(item);
                                nums += string.IsNullOrEmpty(item.nums) ? 0 : float.Parse(item.nums);
                                money += string.IsNullOrEmpty(item.money) ? 0 : float.Parse(item.money);
                                weight += string.IsNullOrEmpty(item.weight) ? 0 : float.Parse(item.weight);
                            }
                            dispatchingWarehouse.nums = nums.ToString();
                            dispatchingWarehouse.money = money.ToString();
                            dispatchingWarehouse.weight = weight.ToString();
                            dispatchDao.addObj(dispatchingWarehouse);
                            dispatchDao.addList(itemList);
                        }

                        //更改库存
                       
                        List<orderSorte> list = sorteDao.getSumBySorteId();
                        if (list != null && list.Count > 0)
                        {
                            for (int j = 0; j < list.Count; j++)
                            {
                                orderSorte obj = list[j];
                                orderdao.updateStoreHouse(obj);
                            }
                        }

                        //改变订单状态
                        orderdao.UpdateStatus(sorteId);
                        loading.Close();
                        MessageBox.Show("分拣完毕!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sortFlag = true;
                        backButton_Click(this, EventArgs.Empty);
                        this.sorteListForm.returnToMain();
                    }));
                    objThread.Start();
                }
                else
                {
                    MessageBox.Show("所有分店尚未分拣完毕，请分拣完毕后再提交数据");
                }
            }
            else
            {
                MessageBox.Show("订单已分拣结束，请返回或退出操作");
            }
        }

        private int getSorteStatus()
        {
            int flag = 0;
            sorteDao dao = new sorteDao();
            string sql = "select AUDITS_TATUS from zc_sorte where id = '"+ConstantUtil.sorte_id+"'";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleDataReader reader = null;
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();
                if(reader.Read()){
                    flag = reader.IsDBNull(0) ? default(int) : reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                log.Error("获取分拣单状态"+ex.Message, ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
                if(reader != null){
                    reader.Close();
                }
            }
            return flag;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void goodDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 4)
            {
                int cot = Convert.ToInt32(goodDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString()) - Convert.ToInt32(goodDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
                if (cot != 0)
                {
                    this.goodDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(201, 67, 65);//Color.Red;
                    this.goodDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    this.goodDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(51, 153, 255);//Color.Blue;
                    this.goodDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        public void color()
        {
            for (int i = 0; i < goodDataGridView.Rows.Count; i++)
            {
                int cot = Convert.ToInt32(goodDataGridView[4, i].Value.ToString().Trim() == "" ? "0" : goodDataGridView[4, i].Value.ToString());
                int cot2 = Convert.ToInt32(goodDataGridView[3, i].Value.ToString().Trim() == "" ? "0" : goodDataGridView[3, i].Value.ToString());

                //int cot = Convert.ToInt32(goodDataGridView[4, i].Value.ToString()) - Convert.ToInt32(goodDataGridView[3, i].Value.ToString());
                if(cot == 0){
                    this.goodDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(201, 67, 65);//Color.Red;
                    this.goodDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else if (cot == cot2)
                {
                    this.goodDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(51, 153, 255);//Color.Blue;
                    this.goodDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else {
                    this.goodDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Orange;//Color.orange;
                    this.goodDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        public void reLoadData()
        {
            if (ConstantUtil.redStatus == 3)
            {
                greenButton.Hide();
                greenLabel.Hide();
                yellowButton.Hide();
                yellowLabel.Hide();
                redButton.Show();
                redLabel.Show();
            }
            else
            {
                greenButton.Hide();
                greenLabel.Hide();
                yellowButton.Show();
                yellowLabel.Show();
                redButton.Hide();
                redLabel.Hide();
            }
            DataSet ds = getGridData();
            if (ds != null && ds.Tables.Count > 0)
            {
                //goodDataGridView.DataSource = ds;
                goodDataGridView.SuspendLayout();
                goodDataGridView.ResumeLayout();
            }

            color();

        }

        private void pTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Timebutton_Click(updateGV);
        }
        int num = 0;
        private string Timebutton_Click(updateGVDelegate updategv_dele)
        {
            //reLoadData();

            num++;
            //nextbutton.Text = num.ToString();
            //getGridData();
            //reLoadData();
            try
            {
                if (this.InvokeRequired)
                {
                    return (string)this.Invoke(updategv_dele);
                }
                else
                {
                    return updategv_dele();
                }
            }
            catch (Exception ex)
            {
                return "1";
            }

        }

        private void goodDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //行号
            using (SolidBrush b = new SolidBrush(this.goodDataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X+5 , e.RowBounds.Location.Y + 4);
            }
        }

        private void goodDataGridView_Paint(object sender, PaintEventArgs e)
        {
            goodDataGridView.ClearSelection();
        }

        private void sorteGoodList_Activated(object sender, EventArgs e)
        {
            
        }


        public void printTicket()
        {
            

           // PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            //设置边距

            Margins margin = new Margins(20, 20, 20, 20);

            pd.DefaultPageSettings.Margins = margin;
            ////纸张设置默认
            
            //XXPaperSize pageSize = new PaperSize("Custom", getYc(60), 10000);


            
            //打印事件设置            

            //string[] strs = GetPrintStr();
            //int len = strs.Length / 70 +1 ;
            //int len2 = 70;
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < strs.Length; i++)
            //{
                
            //        sb.Append(strs[i] + "\n");
            //    Console.WriteLine(sb.ToString());
              
             
               
            //}
            //printString = sb.ToString();
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
            //DataTable dt = ConstantUtil.Branchds.Tables["Zc_sorte_item"];
            //string street = dt.Rows[ConstantUtil.index][13].ToString();
            sortedao = new orderDao();
            branchName = sortedao.getBranchName(ConstantUtil.street);

            StringBuilder sb = new StringBuilder();

            string tou = "宜鲜美配送有限公司";

            string address = "南京市江宁区东麒路66号";

            //string saleID = id_.Text;

            //string item = "品名";

            //decimal price = 25.00M;

            //int count = 5;

            //decimal total = 0.00M;

            //decimal fukuan = 500.00M;



            sb.Append("            " + tou + "     \n");

            sb.Append("-----------------------------------------------------------------\n");

            sb.Append("日期:" + DateTime.Now.ToShortDateString() + "  " + "分店:" + branchName + "\n");

            sb.Append("-----------------------------------------------------------------\n");

            sb.Append("品名" + "\t\t" + "单价" + "\t" + "重/数量" + "\t" + "小计" + "\n");
            //for (int i = 0; i < itemDataGridView.RowCount; i++)
            //{
            //    int actualnums = itemDataGridView[4, i].Value == null ? 0 : Convert.ToInt32(itemDataGridView[4, i].Value);
            //    if (actualnums != 0)
            //    {
            //        string name = itemDataGridView[1, i].Value == null ? "" : itemDataGridView[1, i].Value.ToString();
            //        if (name.Length < 4)
            //        {
            //            name += "\t\t";
            //        }
            //        else if (name.Length <= 6)
            //        {
            //            name += "\t";
            //        }
            //        else
            //        {
            //            name = name.Substring(0, 6) + "... ";
            //        }
            //        string price = itemDataGridView[2, i].Value == null ? "" : itemDataGridView[2, i].Value.ToString();
            //        price = float.Parse(price).ToString("0.00");
            //        string amount = itemDataGridView[7, i].Value == null ? "" : itemDataGridView[7, i].Value.ToString();
            //        amount = float.Parse(amount).ToString("0.00");
            //        sb.Append(name + price + "\t" + actualnums + "\t" + amount + "\n");
            //    }
            //}
            float totalSum = 0;
            float totalAmount = 0;
            string sql = "select a.goods_id, a.goods_name, a.SORTENUM, a.WEIGHT, b.GOODS_PRICE, b.GOODS_UNIT,a.money from ZC_ORDERS_SORTE a left join ZC_GOODS_MASTER b "
                +" on a.GOODS_ID = b.SERIALNUMBER where a.ADDRESS = :street and a.SORTEID = :sorteId order by b.serialnumber ";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":street", ConstantUtil.street);
                cmd.Parameters.Add(":sorteId", ConstantUtil.sorte_id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { 
                    string serialNumber = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    string name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
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
                log.Error(ex.Message , ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
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

        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //SetInvoiceData(e.Graphics);
            Graphics g = e.Graphics;
            Font InvoiceFont = new Font("Arial", 10, FontStyle.Regular);
            SolidBrush GrayBrush = new SolidBrush(Color.Black);
            //RectangleF f = new RectangleF(5, 5, getYc(60), 10000000);
            //StringFormat ff = new StringFormat();
            //g.DrawString(GetPrintStr(), InvoiceFont, GrayBrush, f, null);
            string[] strs = GetPrintStr();
            //g.DrawString(GetPrintStr()[0], InvoiceFont, GrayBrush, 5, 5);
            //g.DrawString(GetPrintStr()[1], InvoiceFont, GrayBrush, 5, 20);
            //g.DrawString(GetPrintStr()[2], InvoiceFont, GrayBrush, 5, 35);
            //int y = 20;
            int y = 0;
            while (index < strs.Length)
            {
                g.DrawString(GetPrintStr()[index++], InvoiceFont, GrayBrush, 5, 5+y);
                y += 15;
                if (y > e.PageBounds.Height)
                {
                    e.HasMorePages = true;
                    return;
                }

            }
            index = 0;
            e.HasMorePages = false;
            //g.Dispose();
        }

        //private void SetInvoiceData(Graphics g)
        //{
        //    Font InvoiceFont = new Font("Arial", 10, FontStyle.Bold);
        //    SolidBrush GrayBrush = new SolidBrush(Color.Black);
        //    g.DrawString(GetPrintStr(), InvoiceFont, GrayBrush, 5, 5);
        //    g.Dispose();
        //}

        private void sorteGoodList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A){
                backButton_Click(this, EventArgs.Empty);
            }else if(e.KeyCode == Keys.S){
                startButton_Click(this, EventArgs.Empty);
            }else if(e.KeyCode == Keys.D){
                endButton_Click(this, EventArgs.Empty);
            }else if(e.KeyCode == Keys.F){
                nextbutton_Click(this, EventArgs.Empty);
            }
            else if(e.KeyCode == Keys.Multiply)
            {
                if(saledatagridview.DataSource == null || saledatagridview.RowCount == 0){
                    return;
                }else
                {
                    bool isWeight = "1".Equals(saledatagridview.CurrentRow.Cells[6].Value.ToString()) ? true : false;
                    if(!isWeight)
                    {
                        string orderSorteId = saledatagridview.CurrentRow.Cells[5].Value.ToString();
                        float money = (saledatagridview.CurrentRow.Cells[3].Value == null || string.IsNullOrEmpty(saledatagridview.CurrentRow.Cells[3].Value.ToString())) ? 0F : float.Parse(saledatagridview.CurrentRow.Cells[3].Value.ToString());
                        ChangeNums changeNums = new ChangeNums(saledatagridview.CurrentRow.Cells[4].Value.ToString(), money, orderSorteId, this);
                        changeNums.Show();
                    }else
                    {
                        MessageBox.Show("该商品为称重商品,无法进行手动数量修改!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }
            else if(e.KeyCode == Keys.Escape)
            {
                leaveButton_Click(this, EventArgs.Empty);
            }
            else if(e.KeyCode == Keys.Delete)
            {
                deleteSale();
            }                
            else if(e.KeyCode == Keys.F1)
            {
                calculateButton_Click(this, EventArgs.Empty);
            }else if(e.KeyCode == Keys.Space)
            {
                if(isResale){
                    goodTablePanel.Show();
                    salepanel.Hide();
                    isResale = false;
                }else
                {
                    goodTablePanel.Hide();
                    salepanel.Show();
                    loadSaleTable();
                    isResale = true;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (isResale)
                {
                    if (saledatagridview.DataSource == null || saledatagridview.RowCount == 0)
                    {
                        return;
                    }
                    int index = saledatagridview.CurrentRow.Index;
                    if(index > 0){
                        saledatagridview.Rows[index - 1].Selected = true;
                        saledatagridview.CurrentCell = saledatagridview.Rows[index - 1].Cells[0];
                    }
                }
                else {
                    if (select_value > 0)
                    {
                        select_value -= 1;
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (isResale)
                {
                    if (saledatagridview.DataSource == null || saledatagridview.RowCount == 0)
                    {
                        return;
                    }
                    int index = saledatagridview.CurrentRow.Index;
                    if (index < saledatagridview.RowCount - 1)
                    {
                        saledatagridview.Rows[index + 1].Selected = true;
                        saledatagridview.CurrentCell = saledatagridview.Rows[index + 1].Cells[0];
                    }
                }
                else
                {
                    if (goodDataGridView.DataSource == null || goodDataGridView.RowCount == 0)
                    {
                        return;
                    }
                    if (select_value < goodDataGridView.Rows.Count - 1)
                    {
                        select_value += 1;
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (goodDataGridView.DataSource == null || goodDataGridView.RowCount == 0)
                {
                    return;
                }
                if (select_value - goodDataGridView.DisplayedRowCount(false) >= 0)
                {
                    select_value -= goodDataGridView.DisplayedRowCount(false);
                }
                else
                {
                    select_value = 0;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (goodDataGridView.DataSource == null || goodDataGridView.RowCount == 0)
                {
                    return;
                }
                if (select_value + goodDataGridView.DisplayedRowCount(false) < goodDataGridView.RowCount - 1)
                {
                    select_value += goodDataGridView.DisplayedRowCount(false);
                }
                else 
                {
                    select_value = goodDataGridView.RowCount - 1;
                }
            }
            else if(numberTextBox.Focused && e.KeyCode == Keys.Enter)
            {
                try
                {
                    AddGoods();
                    loadSaleTable();
                }
                catch (Exception ex) {
                    log.Error("语音播报发生错误", ex);
                }
            }
        }

        private void loadSaleTable()
        {
            string sql = "select b.id as goodsFileId, b.serialNumber, a.id, a.goods_name as goodsname, a.weight,a.money,a.isWeight from zc_orders_sorte a left join zc_goods_master b on a.goods_id = b.id where a.address = '" + dt.Rows[ConstantUtil.index][14]+"' and a.sorteId = '"+ConstantUtil.sorte_id+"'  order by a.createTime";
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
                saledatagridview.AutoGenerateColumns = false;
                saledatagridview.DataSource = dataset;
                saledatagridview.DataMember = "zc_orders_sorte";
                if (saledatagridview.RowCount - 1 >= 0)
                {
                    saledatagridview.Rows[saledatagridview.RowCount - 1].Selected = true;
                    saledatagridview.CurrentCell = saledatagridview.Rows[saledatagridview.RowCount - 1].Cells[0];
                }
            }
            catch (Exception ex)
            {
                log.Error("加载扫码流水信息失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
        }

        private void loadTableAfterDelete(int  index)
        {
            string sql = "select b.id as goodsFileId, b.serialNumber, a.id, a.goods_name as goodsname, a.weight,a.money,a.isWeight from zc_orders_sorte a left join zc_goods_master b on a.goods_id = b.id where a.address = '" + dt.Rows[ConstantUtil.index][14] + "' and a.sorteId = '" + ConstantUtil.sorte_id + "'  order by a.createTime";
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
                saledatagridview.AutoGenerateColumns = false;
                saledatagridview.DataSource = dataset;
                saledatagridview.DataMember = "zc_orders_sorte";
                if (saledatagridview.DataSource == null || saledatagridview.RowCount == 0)
                {

                }
                else
                {
                    if (saledatagridview.RowCount - 1 >= index)
                    {
                        saledatagridview.Rows[index].Selected = true;
                        saledatagridview.CurrentCell = saledatagridview.Rows[index].Cells[0];
                    }
                    else
                    {
                        saledatagridview.Rows[saledatagridview.RowCount - 1].Selected = true;
                        saledatagridview.CurrentCell = saledatagridview.Rows[saledatagridview.RowCount - 1].Cells[0];
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
                if(conn != null){
                    conn.Close();
                }
            }
        }

        //扫码
        private void AddGoods()
        {
            SpeechVoiceSpeakFlags speakflag = SpeechVoiceSpeakFlags.SVSFlagsAsync;
            SpVoice voice = new SpVoice();
            string num = numberTextBox.Text;
            numberTextBox.Text = "";
            ///18位条码和13位条码混合
            if (string.IsNullOrEmpty(num) || (num.Length != 18 && num.Length != 13 && num.Length != 5))
            {

                voice.Speak("错误", speakflag);
                //MessageBox.Show("请确认扫码的条码是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ///以后的13的条码
            //if(string.IsNullOrEmpty(num) || num.Length != 13)
            //{
            //    MessageBox.Show("请确认扫码的条码是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    numberTextBox.Text = "";
            //    return;
            //}
            ///扫码扫出来的结果
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
                //MessageBox.Show("没有此货号对应的商品信息，请检查后重新操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                else {
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

            DataSet ds = (DataSet)this.goodDataGridView.DataSource;
            bool flag = false;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string serialNum = this.goodDataGridView[0, i].Value == null ? "" : this.goodDataGridView[0, i].Value.ToString();
                if (serialNum.Equals(serialNumber))
                {
                    string nums = this.goodDataGridView[4, i].Value == null || "".Equals(this.goodDataGridView[4, i].Value) ? "0" : this.goodDataGridView[4, i].Value.ToString();
                    string orderNums = this.goodDataGridView[3, i].Value.ToString();

                    flag = true;
                    ///start 减去判断
                    if ((string.IsNullOrEmpty(nums) || "0".Equals(nums)) && !calFlag)
                    {
                        voice.Speak("错误", speakflag);
                        //MessageBox.Show("此商品份数为0无法进行减去操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        calFlag = true;
                        calculateButton.Text = "加(F1)";
                        return;
                    }
                    else
                    {
                        orderSorte orderSorte = new orderSorte();
                        orderSorte.createTime = DateTime.Now;
                        orderSorte.updateTime = DateTime.Now;
                        orderSorte.address = ConstantUtil.street;
                        orderSorte.goods_id = this.goodDataGridView.Rows[i].Cells[5].Value == null ? "" : this.goodDataGridView.Rows[i].Cells[5].Value.ToString();
                        orderSorte.id = Guid.NewGuid().ToString();
                        orderSorte.goods_name = this.goodDataGridView.Rows[i].Cells[2].Value == null ? "" : this.goodDataGridView.Rows[i].Cells[2].Value.ToString();
                        //订单份数
                        orderSorte.orderNum = this.goodDataGridView.Rows[i].Cells[3].Value == null ? "" : this.goodDataGridView.Rows[i].Cells[3].Value.ToString();

                        orderSorte.weight = weight;
                        orderSorte.money = money;
                        orderSorte.isWeight = isWeight ? "1" : "0";
                        orderSorte.bar_code = num;
                        sorteDao sortedao = new sorteDao();
                        if (calFlag)
                        {
                            orderSorte.sorteNum = "1";
                            sortedao.AddtransitItem(orderSorte);
                        }
                        else
                        {
                            List<string> list = sortedao.FindBy(orderSorte.goods_id, weight, ConstantUtil.street);
                            if (list.Count == 0)
                            {
                                voice.Speak("错误", speakflag);
                                //MessageBox.Show("没有此商品对应得分拣记录，无需进行减去操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            sortedao.DeleteBy(list[0]);
                            calFlag = true;
                            calculateButton.Text = "加(F1)";
                        }
                    }
                }
                else
                {

                }
            }
            if (!flag)
            {
                voice.Speak("错误", speakflag);
                //MessageBox.Show("没有此商品，请确认商品或者货号是否正确", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
        }

        //private int _ScrollValue = 0;

        //private void goodDataGridView_Scroll(object sender, ScrollEventArgs e)
        //{
        //    if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
        //    {
        //        _ScrollValue = e.NewValue;
        //        isScollbar = true;
        //    }
        //}

        /// <summary>
        /// 限制输入条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 加减标识   默认加  true
        /// </summary>
        private bool calFlag = true;

        private bool isScollbar = false;

        /// <summary>
        /// 加减点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (calFlag)
            {
                calculateButton.Text = "减(F1)";
                calFlag = false;
            }
            else {
                calculateButton.Text = "加(F1)";
                calFlag = true;
            }
        }

        /// <summary>
        /// 焦点离开扫码框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberTextBox_Leave(object sender, EventArgs e)
        {
            numberTextBox.Focus();
        }

        private void saledatagridview_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //行号
            using (SolidBrush b = new SolidBrush(this.saledatagridview.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
            }
        }

        public void reLoadSaleTable()
        {
            loadSaleTable();
        }

        Loading loading;

        private void endSorte()
        {
             loading = new Loading();
            loading.Show();
        }

        private void deleteSale()
        {
            if (saledatagridview.DataSource == null || saledatagridview.RowCount == 0)
            {
                return;
            }
            string name = saledatagridview.CurrentRow.Cells[1].Value == null ? "" : saledatagridview.CurrentRow.Cells[1].Value.ToString();
            int index = saledatagridview.CurrentRow.Index;
            DialogResult dr = MessageBox.Show("确定删除"+name+"?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK){
                sorteDao sortedao = new sorteDao();
                String orderSorteId = saledatagridview.CurrentRow.Cells[5].Value.ToString();
                sortedao.DeleteBy(orderSorteId);
                loadTableAfterDelete(index);
            }
                     
        }

        /// <summary>
        /// 开始分拣
        /// </summary>
        public void startSorte()
        {
            startButton_Click(this, EventArgs.Empty);
        }

        private void saledatagridview_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 2){
                e.Value = Convert.ToDecimal(e.Value).ToString("#0.0000");
            }else if(e.ColumnIndex == 3){
                e.Value = Convert.ToDecimal(e.Value).ToString("#0.00");
            }
        }
    }
}
