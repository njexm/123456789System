using Branch;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.dao;
using sorteSystem.com.proem.sorte.domain;
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
    public partial class Process : Form
    {
        /// <summary>
        /// 标识扫码为加还是减
        /// </summary>
        private bool CalculateFlag = true;

        /// <summary>
        /// 主窗口
        /// </summary>
        private Main mainForm;

        //加工单id
        private string processGoodsId;

        public Process()
        {
            InitializeComponent();
        }

        public Process(Main main)
        {
            InitializeComponent();
            this.mainForm = main;
        }

        /// <summary>
        /// 加工页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Process_Load(object sender, EventArgs e)
        {
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();
            ///初始化下拉框数据
            //initCombox();
            numberTextBox.Focus();
        }

        ///// <summary>
        ///// 初始化下拉框数据
        ///// </summary>
        //private void initCombox()
        //{
        //    DateTime first = DateTime.Today;
        //    DateTime last = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
        //    OracleConnection conn = null;
        //    OracleCommand cmd = new OracleCommand();
        //    string sql = "select id, odd from ZC_PROCESSGOODS where statue != '4' and createtime between :first and :last  order by CREATETIME DESC";
        //    try
        //    {
        //        conn = OracleUtil.OpenConn();
        //        cmd.Connection = conn;
        //        cmd.CommandText = sql;
        //        cmd.Parameters.Add(":first", first);
        //        cmd.Parameters.Add(":last", last);
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            com.proem.sorte.domain.Process p = new com.proem.sorte.domain.Process();
        //            p.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
        //            p.Odd = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
        //            this.comboBox1.Items.Add(p);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        OracleUtil.CloseConn(conn);
        //    }
        //    this.comboBox1.DisplayMember = "Odd";
        //    this.comboBox1.ValueMember = "Id";
        //}

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //com.proem.sorte.domain.Process p = (com.proem.sorte.domain.Process)this.comboBox1.SelectedItem;
        //    this.itemDataGird.DataSource = null;
        //    loadDataGridView();
        //    numberTextBox.Focus();
        //    numberTextBox.Text = "";
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定退出系统?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                //释放全部连接池资源
                OracleConnection.ClearAllPools();
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
            }
        }

        /// <summary>
        /// 快捷键绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Process_KeyDown(object sender, KeyEventArgs e)
        {
            if (numberTextBox.Focused && e.KeyCode == Keys.Enter)
            {
                AddGoods();
            }
            if(e.KeyCode == Keys.Escape)
            {
                button1_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.F1)
            {
                calculateButton_Click(this, EventArgs.Empty);
            }
            if(e.KeyCode == Keys.F2)
            {
                processList processForm = new processList(this);
                processForm.StartPosition = FormStartPosition.CenterScreen;
                processForm.Show();
            }
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        private void AddGoods()
        {
            if (oddText.Text == "按F2选择加工单")
            {
                MessageBox.Show("扫码前，请选择一条加工单!");
                numberTextBox.Text = "";
                return;
            }
            if (string.IsNullOrEmpty(numberTextBox.Text))
            {
                return;
            }
            //现在还是18位条码
            if (numberTextBox.Text.Length != 18 || !numberTextBox.Text.StartsWith("28"))
            {
                MessageBox.Show("请检查条码是否正确!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                numberTextBox.Text = "";
                return;
            }
            //以后的13位条码
            //if (numberTextBox.Text.Length != 13 || !numberTextBox.Text.StartsWith("28"))
            //{
            //    MessageBox.Show("请检查条码是否正确!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    numberTextBox.Text = "";
            //    return;
            //}
            ///以后的13位条码
            //string serialNumber = numberTextBox.Text.Substring(2, 5);
            //string weightString = numberTextBox.Text.Substring(7, 5);
            //float weigth = float.Parse(weightString.Insert(2, "."));
            ///现在的18位条码
            string serialNumber = numberTextBox.Text.Substring(2, 5);
            string weightString = numberTextBox.Text.Substring(12, 5);
            float weigth = float.Parse(weightString.Insert(2, "."));
            string processItemId = "";

            if (this.itemDataGird.DataSource != null && this.itemDataGird.RowCount != 0)
            {
                for (int i = 0; i < itemDataGird.RowCount; i++)
                {
                    if (itemDataGird[1, i].Value.ToString() == serialNumber)
                    {
                        processItemId = itemDataGird[0, i].Value.ToString();
                        break;
                    }
                }
            }
            ProcessItem item = new ProcessItem();
            ProcessItemDao dao = new ProcessItemDao();
            if (string.IsNullOrEmpty(processItemId))
            {
                if (CalculateFlag)
                {
                    ///新增数据
                    OracleConnection conn = null;
                    OracleCommand cmd = new OracleCommand();
                    string sql = "select id,GOODS_NAME,GOODS_SPECIFICATIONS,GOODS_UNIT  from ZC_GOODS_MASTER where SERIALNUMBER = :serialNumber";
                    try
                    {
                        conn = OracleUtil.OpenConn();
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.Parameters.Add(":serialNumber", serialNumber);
                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            item.GoodsFileId = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                            item.GoodsName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            item.Specifications = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            item.Unit = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        //OracleUtil.CloseConn(conn);
                    }
                    item.Id = Guid.NewGuid().ToString();
                    item.CreateTime = DateTime.Now;
                    item.UpdateTime = DateTime.Now;
                    item.GoodsNum = "1";
                    item.ProcessGoodsId = processGoodsId;
                    item.SerialNumber = serialNumber;
                    item.TypeFlag = "2";
                    item.GoodsWeight = weigth.ToString();
                    dao.AddProcessItem(item);
                }
                else
                {
                    MessageBox.Show("当前加工单不存在此商品，无法扫码减去!");
                    numberTextBox.Text = "";
                    return;
                }
            }
            else
            {
                ///更新数据
                item = dao.FindById(processItemId);
                if (CalculateFlag)
                {
                    item.GoodsNum = (float.Parse(item.GoodsNum) + 1).ToString();
                    item.GoodsWeight = (float.Parse(item.GoodsWeight) + weigth).ToString();
                    item.CreateTime = DateTime.Now;
                    item.UpdateTime = DateTime.Now;
                    dao.UpdateItem(item);
                }
                else
                {
                    if (float.Parse(item.GoodsWeight) < weigth)
                    {
                        MessageBox.Show(item.GoodsName + "的重量小于需要减去的商品数量, 扫码失败!");
                        numberTextBox.Text = "";
                        return;
                    }
                    else if (float.Parse(item.GoodsWeight) == weigth)
                    {
                        dao.DeleteById(processItemId);
                    }
                    else
                    {
                        item.GoodsNum = (float.Parse(item.GoodsNum) - 1).ToString();
                        item.GoodsWeight = (float.Parse(item.GoodsWeight) - weigth).ToString();
                        item.CreateTime = DateTime.Now;
                        item.UpdateTime = DateTime.Now;
                        dao.UpdateItem(item);
                    }
                }
            }
            /// 更新主表

            ProcessDao mainDao = new ProcessDao();
            string goodsNum = mainDao.FindGoodsNum(processGoodsId);
            if (CalculateFlag)
            {
                if (string.IsNullOrEmpty(goodsNum))
                {
                    goodsNum = "1";
                }
                else
                {
                    goodsNum = (float.Parse(goodsNum) + 1).ToString();
                }
            }
            else
            {
                goodsNum = (float.Parse(goodsNum) - 1).ToString();
                
            }
            
            mainDao.updateNum(processGoodsId, goodsNum);
            loadDataGridView();
            ///清空条码
            numberTextBox.Text = "";
            ///每次扫码结束，默认是+
            calculateButton.Text = "加(F1)";
            CalculateFlag = true;
        }

        private void loadDataGridView()
        {
            string sql = "select e.id, e.serialNumber, e.goodsName, e.specifications, e.unit, e.goodsWeight, e.goodsNum ,f.nums as ordernums "
                + " from zc_processgoods_items e left join (select sum(nums) as nums,wasterate,goods_state,name,goods_specifications,serialNumber,goodsfile_id "
                + " from (select b.goodstype_id,b.wasterate,a.createtime,a.goods_state,a.name, "
                + " a.nums,b.goods_specifications,b.id as goodsfile_id,b.serialNumber "
                + " from ZC_ORDER_process_ITEM a left join ZC_ORDER_process e on e.id = a.order_id "
                + " left join zc_goods_master b on a.goodsfile_id = b.id where a.goods_state = '2' "
                + " )group by name,wasterate,goods_specifications,serialNumber,goodsfile_id,goods_state order by serialNumber asc "
                + " )f on e.serialNumber = f.serialnumber where e.processgoodsId = :processId "
                + " and e.typeflag = '2' order by e.UPDATETIME desc ";
            DataSet ds = new DataSet();
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.Add(":processId", processGoodsId);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds, "zc_processgoods_items");
                this.itemDataGird.DataSource = ds;
                this.itemDataGird.DataMember = "zc_processgoods_items";
                this.itemDataGird.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                //OracleUtil.CloseConn(conn);
            }
        }

        /// <summary>
        /// 显示数据格式化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemDataGird_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (itemDataGird.Columns[e.ColumnIndex].Name == "specifications")
            {
                if (e.Value == null || e.Value.ToString() == "")
                {
                    return;
                }
                string str = e.Value.ToString();
                e.Value = str.Replace("商品规格：", "");
            }
            if (itemDataGird.Columns[e.ColumnIndex].Name == "goodsWeight")
            {
                if (e.Value == null || e.Value.ToString() == "")
                {
                    return;
                }
                string str = e.Value.ToString();
                e.Value = float.Parse(str).ToString("0.000");
            }
        }

        /// <summary>
        /// 点击运算符事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (CalculateFlag)
            {
                ///原本为+，点击后变为-
                calculateButton.Text = "减(F1)";
                CalculateFlag = false;
            }
            else 
            {
                ///原本为-,点击后变为+
                calculateButton.Text = "加(F1)";
                CalculateFlag = true;
            }
            numberTextBox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.mainForm.Show();
            this.Close();
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

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
        /// 设置选择的加工单
        /// </summary>
        /// <param name="odd"></param>
        /// <param name="id"></param>
        public void setOddAndProcessId(string odd, string id)
        {
            oddText.Text = odd;
            processGoodsId = id;
            loadDataGridView();
            numberTextBox.Focus();
        }
    }
}
