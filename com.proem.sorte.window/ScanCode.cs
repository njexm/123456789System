using Branch;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.dao;
using sorteSystem.com.proem.sorte.util;
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
    public partial class ScanCode : Form
    {
        private delegate string updateGVDelegate();
        private string updateGV()
        {
            DataSet ds = getGridData();
            goodDataGridView.DataSource = ds;
            goodDataGridView.CurrentCell = null;
            //color();
            return "1";
        }

        private DataSet ds = null;

        DataTable dt;
        orderDao sortedao;
        string branchName;
        object result;

        public ScanCode()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加减标识   默认加  true
        /// </summary>
        private bool calFlag = true;

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (calFlag)
            {
                calculateButton.Text = "减(F1)";
                calFlag = false;
            }
            else
            {
                calculateButton.Text = "加(F1)";
                calFlag = true;
            }
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanCode_Load(object sender, EventArgs e)
        {
            numberTextBox.Focus();
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();

            //后台刷新数据
            System.Timers.Timer pTimer = new System.Timers.Timer(1000);//每隔5秒执行一次，没用winfrom自带的
            pTimer.Elapsed += new System.Timers.ElapsedEventHandler(pTimer_Elapsed);//委托，要执行的方法
            pTimer.AutoReset = true;//获取该定时器自动执行
            pTimer.Enabled = true;//这个一定要写，要不然定时器不会执行的
            Control.CheckForIllegalCrossThreadCalls = false;//这个不太懂，有待研究
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
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
            }     
        }

        public DataSet getGridData()
        {
            loadStreetAndOthers();
            try
            {
                OracleConnection connection = OracleUtil.OpenConn();
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
                                + " left join zc_order_process b on b.id=a.order_id left join zc_goods_master c on c.id=a.goodsfile_id left join (select SUM(sortenum) as sortenum,goods_id ,address from ZC_ORDERS_SORTE GROUP by goods_id, address) d on d.goods_id = c.id and b.branchid=d.address  left join zc_workstation e on e.id = c.zcuserinfo"
                                + " where branchid = '" + result + "' ) "
                                + "group by name,serialNumber,goodsfile_id,branchid,sorteNum,workname,workcode order by serialNumber";
                    OracleCommand cmd = new OracleCommand(sql, connection);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Zc_sorte_item");

                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return ds;
        }

        private string remark;        

        private void loadStreetAndOthers()
        {
            string sql = "select a.street,a.sorteId, b.REMARK from ZC_SORTE_STATUS a left join ZC_SORTE_ITEM b on a.sorteId = b.SORTE_ID and a.STREET = b.ADDRESS ";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            finally
            { 
            
            }
        }

        public void color()
        {
            for (int i = 0; i < goodDataGridView.Rows.Count; i++)
            {
                int cot = Convert.ToInt32(goodDataGridView[4, i].Value.ToString().Trim() == "" ? "0" : goodDataGridView[4, i].Value.ToString());
                int cot2 = Convert.ToInt32(goodDataGridView[3, i].Value.ToString().Trim() == "" ? "0" : goodDataGridView[3, i].Value.ToString());

                //int cot = Convert.ToInt32(goodDataGridView[4, i].Value.ToString()) - Convert.ToInt32(goodDataGridView[3, i].Value.ToString());
                if (cot != cot2)
                {
                    this.goodDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(201, 67, 65);//Color.Red;
                    this.goodDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    this.goodDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(51, 153, 255);//Color.Blue;
                    this.goodDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void ScanCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape){
                button1_Click(this, EventArgs.Empty);
            }else if(e.KeyCode == Keys.F1)
            {
                calculateButton_Click(this, EventArgs.Empty);
            }else if(numberTextBox.Focused && e.KeyCode == Keys.Enter){
            
            }
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
    }
}
